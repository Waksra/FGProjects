#pragma once
#define PLAYER_MAX 20

class Player
{
public:
	int id = -1;
	bool alive = false;
	float x;
	float y;

	void spawn(int id, float spawnX, float spawnY);
	void destroy();

	bool hasControl();

	void update();

	void draw();
};

extern Player players[PLAYER_MAX];

#if CLIENT
extern int possessedPlayerId;
#endif

