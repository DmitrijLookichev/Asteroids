using System.Collections.Generic;

using Unity.Mathematics;

namespace Asteroids.Core
{ 
	public struct GameData
	{
		private int _score;
		private readonly int[] _costs;

		public Stack<float3> SmallAsteroids { get; }

		public Interval AsteroidSpawnInterval { get; }
		public Interval AlienSpawnInterval { get; }
		public IntervalInt SpawnSmallAsteroids { get; }

		
		public float AsteroidSpawnTime { get; set; }
		public float AlienSpawnTime { get; set; }

		public int Score => _score;


		public void AddScore(ObjectType type)
		{
			_score += _costs[(int)type];
		}

		public GameData(int[] costs, IntervalInt spawnSmallAsteroids,
			Interval asteroidSpawnInterval, Interval alienSpawnInterval)
		{
			SmallAsteroids = new Stack<float3>(8);
			_costs = costs;
			(AsteroidSpawnInterval, AlienSpawnInterval, SpawnSmallAsteroids) 
				= (asteroidSpawnInterval, alienSpawnInterval, spawnSmallAsteroids);

			AsteroidSpawnTime = AsteroidSpawnInterval.Min;
			AlienSpawnTime = AlienSpawnInterval.Max;
			_score = 0;
		}
	}
}
