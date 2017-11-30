#pragma once
#include <vector>
#include <windows.h>  
#include <vcclr.h>  

#using <System.dll> 

using namespace System;
//source http://mrl.nyu.edu/~perlin/noise/)

public ref class PerlinNoise {

	std::vector<char>& map;
	int height;
	int width;

	std::vector<int>& p;
	double noise(double x, double y, double z);
	double fade(double t);
	double lerp(double t, double a, double b);
	double grad(int hash, double x, double y, double z);
public:
	PerlinNoise(int seed, int height, int width);
	array<Byte>^ getMap();

};
