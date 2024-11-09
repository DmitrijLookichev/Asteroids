using Asteroids.Common.Actors;
using Asteroids.Common.Presets;

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
			public ShipPreset Preset;
		}

		[System.Serializable]
		public struct ColliderSettings
		{
			[SerializeField]
			public ColliderActor Prefab;
			[SerializeField]
			public ColliderPreset Preset;
		}
#endregion

		[field: SerializeField]
		public ShipSettings Player { get; private set; }
		[field: SerializeField]
		public ShipSettings Alien { get; private set; }
		[field: SerializeField]
		public ColliderSettings Projectile { get; private set; }
		[field: SerializeField]
		public ColliderSettings BigAsteroid { get; private set; }
		[field: SerializeField]
		public ColliderSettings SmallAsteroid { get; private set; }

		//todo добавить настройки сцены:
		//скока очков за кого
		//как часто спавнятся те и другие
		//как много тех и других может быть одновременно
	}
}
