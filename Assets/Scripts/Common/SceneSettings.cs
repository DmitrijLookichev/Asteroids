using Asteroids.Common.Actors;
using Asteroids.Common.Presets;
using Asteroids.Core;

using UnityEngine;

namespace Asteroids.Common
{
	[CreateAssetMenu(fileName = "NewSceneSettings", menuName = "Presets/Scene Config", order = 0)]
	public class SceneSettings : ScriptableObject
	{
#region Internal structs
		[System.Serializable]
		public struct ShipSettings
		{
			[SerializeField]
			public ShipActor Prefab;
			[SerializeField]
			public ShipActorPreset Preset;
		}

		[System.Serializable]
		public struct ColliderSettings
		{
			[SerializeField]
			public Actor Prefab;
			[SerializeField]
			public ColliderPreset Preset;
		}
#endregion

		[field: SerializeField]
		public ShipSettings Player { get; private set; }
		[field: SerializeField]
		public ShipSettings Alien { get; private set; }
		[field: SerializeField]
		public ColliderSettings ProjectilePlayer { get; private set; }
		[field: SerializeField]
		public ColliderSettings ProjectileAlien { get; private set; }
		[field: SerializeField]
		public ColliderSettings BigAsteroid { get; private set; }
		[field: SerializeField]
		public ColliderSettings SmallAsteroid { get; private set; }

		[field: SerializeField, Space(10f)]
		public Interval AsteroidSpawnInterval { get; private set; } = new Interval(3f, 10f);
		[field: SerializeField]
		public Interval AlienSpawnInterval { get; private set; } = new Interval(7f, 15f);
		[field: SerializeField]
		public IntervalInt SpawnSmallAsteroids { get; private set; } = new IntervalInt(2, 4);

		//todo добавить настройки сцены:
		//скока очков за кого
		//как часто спавнятся те и другие
		//как много тех и других может быть одновременно
	}
}
