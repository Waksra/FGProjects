#include "Player.h"

#include "Engine.h"

Player players[PLAYER_MAX];

void Player::spawn(int spawnX, int spawnY)
{
    alive = true;
    x = spawnX;
    y = spawnY;
}

void Player::destroy()
{
    alive = false;
}

void Player::draw()
{
    engSetColor(0xDEADBEEF);
    engFillRect(x, y, 32, 32);
}
