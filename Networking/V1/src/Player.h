#pragma once
#define PLAYER_MAX 20

class Player
{
public:
    bool alive = false;
    int x;
    int y;

    void spawn(int spawnX, int spawnY);
    void destroy();

    void draw();
};

extern Player players[PLAYER_MAX];