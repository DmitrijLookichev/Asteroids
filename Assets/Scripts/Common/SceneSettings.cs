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
		public struct PlayerShipSettings
		{
			[SerializeField]
			public ShipActor Prefab;
			[SerializeField]
			public PlayerShipActorPreset Preset;
		}

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
		[System.Serializable]
		private struct TypePointPair
		{
			public ObjectType Type;
			public int Points;
		}
		#endregion

		[field: SerializeField]
		public PlayerShipSettings Player { get; private set; }
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

		[field: SerializeField, Space(20f)]
		public Interval AsteroidSpawnInterval { get; private set; } = new Interval(3f, 10f);
		[field: SerializeField]
		public Interval AlienSpawnInterval { get; private set; } = new Interval(7f, 15f);
		[field: SerializeField]
		public IntervalInt SpawnSmallAsteroids { get; private set; } = new IntervalInt(2, 4);

		[SerializeField]
		private TypePointPair[] _points;
		public int[] GetPoints
		{
			get
			{
				var points = new int[System.Enum.GetValues(typeof(ObjectType)).Length];
				foreach (var point in _points)
					points[(int)point.Type] = point.Points;
				return points;
			}
		}
	}
}
