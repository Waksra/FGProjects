#include "Player.h"
#include "Engine.h"
#include "MessageType.h"
#include "Network.h"
#include "Client.h"

Player players[PLAYER_MAX];

#if CLIENT
int possessedPlayerId = -1;
#endif

void Player::spawn(int id, float spawnX, float spawnY)
{
	alive = true;
	this->id = id;
	x = spawnX;
	y = spawnY;
}

void Player::destroy()
{
	alive = false;
}

bool Player::hasControl()
{
#if SERVER
	return false;
#else
	return id == possessedPlayerId;
#endif
}

void Player::update() {
#if CLIENT
	if (hasControl())
	{
		const float speed = 500.f;

		float deltaX = 0;
		float deltaY = 0;


		if(engKeyDown(Key::W))
			deltaY -= speed;
		if(engKeyDown(Key::S))
			deltaY += speed;
		if(engKeyDown(Key::D))
			deltaX += speed;
		if(engKeyDown(Key::A))
			deltaX -= speed;

		if(deltaX == 0 && deltaY == 0)
			return;

		float deltaTime = engDeltaTime();
		
		x += deltaX * deltaTime;
		y += deltaY * deltaTime;
		
		NetMessage msg;
		msg.write<MessageType>(MessageType::PlayerPosition);
		msg.write<int>(id);
		msg.write<float>(x);
		msg.write<float>(y);

		clientSend(msg);
		msg.free();
	}
#endif
}

void Player::draw()
{
	engSetColor(0xDEADBEEF);
#if CLIENT
	if(hasControl())
		engSetColor(0xADDEBEEF);
#endif

	engFillRect(static_cast<int>(x), static_cast<int>(y), 32, 32);
}
