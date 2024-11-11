﻿using Unity.Mathematics;

namespace Asteroids.Core
{ 
	public struct GameData
	{
		private readonly int[] _costs;

		public readonly Interval AsteroidSpawnInterval;
		public readonly Interval AlienSpawnInterval;
		public readonly IntervalInt SpawnSmallAsteroids;

		public float AsteroidSpawnTime;
		public float AlienSpawnTime;
		public int Score { get; private set; }
		

		public void AddScore(ObjectType type)
		{
			Score += _costs[(int)type];
		}

		public GameData(int[] costs, IntervalInt spawnSmallAsteroids,
			Interval asteroidSpawnInterval, Interval alienSpawnInterval)
		{
			_costs = costs;
			(AsteroidSpawnInterval, AlienSpawnInterval, SpawnSmallAsteroids) 
				= (asteroidSpawnInterval, alienSpawnInterval, spawnSmallAsteroids);

			AsteroidSpawnTime = AsteroidSpawnInterval.Min;
			AlienSpawnTime = AlienSpawnInterval.Max;
			Score = 0;
		}
	}
}
