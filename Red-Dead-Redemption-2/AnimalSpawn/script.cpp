/*
	THIS FILE IS A PART OF RDR 2 SCRIPT HOOK SDK
				http://dev-c.com
			(C) Alexander Blade 2019
*/

// 'script.cpp' HAS BEEN EXTREMELY HEAVILY MODIFIED FROM THE ORIGINAL SDK, 'script.h' HAS ALSO BEEN MODIFIED, I USED THIS VISUAL STUDIO SOLUTION AS A TEMPLATE TOO BUILD OFF OF. THE SUPPORTING FILES FOR
// 'script.cpp' AND 'script.h HAS BEEN UNMODIFIED //

// STARTING POINT 'script.cpp' //

/*
#include "script.h"
#include <string>
#include <vector>


void update()
{

}

void main()
{
	while (true)
	{
		update();
		WAIT(0);
	}
}

void ScriptMain()
{
	srand(GetTickCount());
	main();
}
*/

// STARTING POINT 'script.h' //

/*
#pragma once

#include "..\..\inc\natives.h"
#include "..\..\inc\types.h"
#include "..\..\inc\enums.h"

#include "..\..\inc\main.h"

void ScriptMain();
*/

#include "script.h"
#include <string>
#include <iostream>
#include <fstream>

int SpawnRate; // HOW OFTEN BEARS SHOULD SPAWNS, READ FROM 'SpawnStats.ini'

// ANIMAL COORDS:
int offsetX;
int offsetY;
int offsetZ;

char* AnimalName;

bool HasSpawned = false; // HAS AN ANIMAL SPAWNED, STOP DUPLICATE BEARS

int lines; // INT TO GO THROUGH EACH LINE IN 'SpawnStats.ini'

void update()
{
	WAIT(SpawnRate);
	Spawn();
}

void Spawn()
{
	if (HasSpawned == true)
	{
		return;
	}
	else
	{
		HasSpawned = true;
		Vector3 coords = ENTITY::GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(PLAYER::PLAYER_PED_ID(), offsetX, offsetY, offsetZ);
		DWORD model = GAMEPLAY::GET_HASH_KEY(AnimalName);
		STREAMING::REQUEST_MODEL(model, false);
		while (!STREAMING::HAS_MODEL_LOADED(model))
		{
			WAIT(0);
		}
		Ped p = PED::CREATE_PED(model, coords.x, coords.y, coords.z, 180, false, false, 0, false);
		PED::SET_PED_VISIBLE(p, TRUE);
		HasSpawned = false;
	}
}

void main()
{
	while (true)
	{
		std::ifstream file;

		file.open("SpawnStats.ini");

		std::string array[10];

		while (!file.eof())
		{
			std::getline(file, array[lines]);
			lines++;
		}

		if (array[1].empty() == false)
		{
			SpawnRate = stoi(array[1]);
		}

		if (array[4].empty() == false)
		{
			offsetX = stoi(array[4]);
		}

		if (array[5].empty() == false)
		{
			offsetY = stoi(array[5]);
		}

		if (array[6].empty() == false)
		{
			offsetZ = stoi(array[6]);
		}

		if (array[9].empty() == false)
		{
			const char* t = array[9].data();
			AnimalName = (char*)t;
		}

		file.close();
		lines = 0;

		update();
		WAIT(0);
	}
}

void ScriptMain()
{
	srand(GetTickCount());
	main();
}
