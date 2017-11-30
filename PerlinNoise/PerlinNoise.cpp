#include "PerlinNoise.h"
#include <iostream>
#include <cmath>
#include <random>
#include <algorithm>
#include <numeric>

// source http://mrl.nyu.edu/~perlin/noise/)


PerlinNoise::PerlinNoise(int seed, int height, int width, double xm, double ym, double zm) : p(std::vector<int>()) {
	this->map = gcnew array<double>(height * width);
	//this->p =  std::vector<int>();
	//this->map = std::vector<unsigned char>();
	p.resize(256);
	this->height = height;
	this->width = width;
	std::iota(p.begin(), p.end(), 0);
	std::default_random_engine engine(seed);
	std::shuffle(p.begin(), p.end(), engine);
	p.insert(p.end(), p.begin(), p.end());

	for (unsigned int i = 0; i < height; ++i) {
		for (unsigned int j = 0; j < width; ++j) {
			double x = (double)j / ((double)width);
			double y = (double)i / ((double)height);

			this->map[i * width + j] = this->noise(xm * x, ym * y, zm);
		}
	}
}


double PerlinNoise::noise(double x, double y, double z) {
	// Find the unit cube 
	int X = (int)floor(x) & 255;
	int Y = (int)floor(y) & 255;
	int Z = (int)floor(z) & 255;

	// Relative x,y,z
	x -= floor(x);
	y -= floor(y);
	z -= floor(z);

	// Fade curves
	double u = fade(x);
	double v = fade(y);
	double w = fade(z);

	// Hashcoordinates
	int A = p[X] + Y;
	int AA = p[A] + Z;
	int AB = p[A + 1] + Z;
	int B = p[X + 1] + Y;
	int BA = p[B] + Z;
	int BB = p[B + 1] + Z;

	double res = lerp(w, lerp(v, lerp(u, grad(p[AA], x, y, z), grad(p[BA], x - 1, y, z)), lerp(u, grad(p[AB], x, y - 1, z), grad(p[BB], x - 1, y - 1, z))), lerp(v, lerp(u, grad(p[AA + 1], x, y, z - 1), grad(p[BA + 1], x - 1, y, z - 1)), lerp(u, grad(p[AB + 1], x, y - 1, z - 1), grad(p[BB + 1], x - 1, y - 1, z - 1))));
	return (res + 1.0) / 2.0;
}

double PerlinNoise::fade(double t) {
	return t * t * t * (t * (t * 6 - 15) + 10);
}

double PerlinNoise::lerp(double t, double a, double b) {
	return a + t * (b - a);
}

double PerlinNoise::grad(int hash, double x, double y, double z) {
	int h = hash & 15;
	// Convert lower 4 bits of hash inot 12 gradient directions
	double u = h < 8 ? x : y,
		v = h < 4 ? y : h == 12 || h == 14 ? x : z;
	return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
}


array<double>^ PerlinNoise::getMap() 
{
	return this->map;
}