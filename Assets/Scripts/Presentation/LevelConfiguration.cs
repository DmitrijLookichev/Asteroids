using Asteroids.Common;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;
using Asteroids.Presentation.Objects;
using Asteroids.Presentation.Presets;

using UnityEngine;
namespace Asteroids.Presentation
{
    public class LevelConfiguration : MonoBehaviour
    {
#region Internal structs
		[System.Serializable]
		private struct ShipSettings
		{
			[SerializeField]
			public ShipProvider Ship;
			[SerializeField]
			public ShipPreset Preset; 
			[SerializeField]
			public VisualProvider Visual;
		}

		[System.Serializable]
		private struct AsteroidSettings
		{
			[SerializeField]
			public VisualProvider Visual;
			//todo add stats
		}
		#endregion

		private World _world;

		[SerializeField]
		private ShipSettings _player;
		[SerializeField]
		private ShipSettings _aliens;
		[SerializeField]
		private AsteroidSettings _asteroids;

		private void Awake()
		{
#if UNITY_EDITOR
			if (CheckReferences()) return;
#endif

			var playerShip = CreateShipAspect(_player.Preset);
			var alienShip = CreateShipAspect(_aliens.Preset);
			_world = new World(playerShip, alienShip);
		}

		private void Update()
		{
			_world.OnUpdate(Time.time, Time.deltaTime);
		}

		private void OnDestroy()
		{
			_world.Dispose();
			_world = null;
		}

		private ShipAspect CreateShipAspect(ShipPreset preset)
		{
			var mobility = new ShipMobility(Mathf.Deg2Rad * preset.RotationSpeed,
				preset.Acceleration, preset.Deceleration, preset.MaxVelocity);
			var aspect = new ShipAspect(mobility, (byte)preset.Lifes,
				preset.FireReload, preset.LaserReload, new ShipInput());

			return aspect;
		}

		//check incorrect settings
#if UNITY_EDITOR

		private bool CheckReferences()
		{
			var error = false;
			if (_player.Ship == null)
				DropError($"NullRef player {nameof(ShipProvider)}", ref error);
			if (_player.Visual == null)
				DropError($"NullRef player {nameof(VisualProvider)}", ref error);
			if (_aliens.Visual == null)
				DropError($"NullRef aliens {nameof(VisualProvider)}", ref error);
			if (_asteroids.Visual == null)
				DropError($"NullRef asteroids {nameof(VisualProvider)}", ref error);
			return error;
		}

		private void DropError(string message, ref bool error)
		{
			UnityEditor.EditorApplication.isPlaying = false;
			Debug.LogError(message, this);
			error = true;
		}
#endif
	}
}
