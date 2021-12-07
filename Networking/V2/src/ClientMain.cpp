#include "Engine.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>
#include "Player.h"
#include "Client.h"
#include "Network.h"
#include "MessageType.h"
#if CLIENT

void handleMessage(NetMessage msg)
{
	MessageType type = msg.read<MessageType>();
	switch (type)
	{
	case MessageType::PlayerSpawn:
		{
			int id = msg.read<int>();
			float x = msg.read<float>();
			float y = msg.read<float>();
			players[id].spawn(id, x, y);

			break;
		}

	case MessageType::PlayerDestroy:
		{
			int id = msg.read<int>();
			players[id].destroy();
			break;
		}

	case MessageType::PlayerPossess:
		{
			possessedPlayerId = msg.read<int>();
			break;
		}
	case MessageType::PlayerPosition:
		{
			int id = msg.read<int>();
			Player* player = &players[id];

			if(player->hasControl())
				break;

			player->x = msg.read<float>();
			player->y = msg.read<float>();
			break;
		}
	default: ;
	}
}

int WinMain(HINSTANCE, HINSTANCE, char*, int)
{
	engInit();
	netInit();

	if (!clientConnect("10.20.2.178", 666))
		return 1;

	while(engBeginFrame() && clientIsConnected())
	{
		NetEvent event;
		while(netPollEvent(&event))
		{
			switch(event.type)
			{
				case NetEventType::Message:
					handleMessage(event.message);
					break;
			}

			event.free();
		}

		engSetColor(0x4444CCFF);
		engClear();

		for (auto& player : players)
		{
			if (player.alive)
				player.update();
		}

		for (auto& player : players)
		{
			if(player.alive)
				player.draw();
		}
	}

	return 0;
}

#endif
