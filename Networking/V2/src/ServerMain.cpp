#include "Engine.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>
#include <stdio.h>
#include <stdlib.h>
#include "Player.h"
#include "Server.h"
#include "Network.h"
#include "MessageType.h"
#if SERVER

void handleMessage(int userId, NetMessage msg)
{
	MessageType type = msg.read<MessageType>();
	switch (type)
	{
	case MessageType::PlayerPosition:
		{
			int playerId = msg.read<int>();
			if(playerId != userId)
			{
				serverKickUser(userId);
				break;
			}
			
			Player* player = &players[userId];
			player->x = msg.read<float>();
			players->y = msg.read<float>();

			serverBroadcast(msg);
			break;
		}
	}
}

int WinMain(HINSTANCE, HINSTANCE, char*, int)
{
	engInit();
	netInit();

	if (!serverStartup(666))
		return 1;

	while(engBeginFrame())
	{
		NetEvent event;
		while(netPollEvent(&event))
		{
			switch(event.type)
			{
				case NetEventType::UserConnected:
					{
						engPrint("User %d connected", event.userId);
						serverAcceptUser(event.userId);

						for (int i = 0; i < PLAYER_MAX; ++i)
						{
							if(!players[i].alive)
								continue;

							NetMessage msg;
							msg.write<MessageType>(MessageType::PlayerSpawn);
							msg.write<int>(i);
							msg.write<float>(players[i].x);
							msg.write<float>(players[i].y);

							serverSendTo(msg, event.userId);
							msg.free();
						}

						{
							Player* player = &players[event.userId];
							player->spawn(event.userId, rand() % 800, rand() % 600);
					
							NetMessage msg;
							msg.write<MessageType>(MessageType::PlayerSpawn);
							msg.write<int>(event.userId);
							msg.write<float>(player->x);
							msg.write<float>(player->y);

							serverBroadcast(msg);
							msg.free();
						}

						{
							NetMessage msg;
							msg.write<MessageType>(MessageType::PlayerPossess);
							msg.write<int>(event.userId);

							serverSendTo(msg, event.userId);
							msg.free();
						}
						
						break;
					}

				case NetEventType::UserDisconnected:
					{
						engPrint("User %d disconnected", event.userId);

					   players[event.userId].destroy();

					   NetMessage msg;
					   msg.write<MessageType>(MessageType::PlayerDestroy);
					   msg.write<int>(event.userId);
					   break;
					}

				case NetEventType::Message:
					handleMessage(event.userId, event.message);
					break;
			}

			event.free();
		}

		engSetColor(0xCC4444FF);
		engClear();

		for (auto& player : players)
		{
			if (player.alive)
				player.update();
		}

		for (auto& player : players)
		{
			if(players->alive)
				players->draw();
		}
	}

	return 0;
}

#endif
