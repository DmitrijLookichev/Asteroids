using Asteroids.Common.Objects;
using Asteroids.Common.Presets;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;

using UnityEngine;
namespace Asteroids.Common
{
    public class SceneController : MonoBehaviour
    {
#region Internal structs
		[System.Serializable]
		private struct ShipSettings
		{
			[SerializeField]
			public ShipBehaviour Prefab;
			[SerializeField]
			public ShipPreset Preset;
		}

		[System.Serializable]
		private struct AsteroidSettings
		{
			[SerializeField]
			public ShipBehaviour Prefab;//todo SHip?
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

			_world = new World((_player.Prefab, _player.Preset),
				(_aliens.Prefab, _aliens.Preset));
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

		//check incorrect settings
#if UNITY_EDITOR

		private bool CheckReferences()
		{
			var error = false;
			if (_player.Prefab == null)
				DropError($"NullRef player {nameof(ShipBehaviour)}", ref error);
			if (_player.Preset == null)
				DropError($"NullRef player {nameof(ShipPreset)}", ref error);
			if (_aliens.Prefab == null)
				DropError($"NullRef aliens {nameof(ShipBehaviour)}", ref error);
			if (_aliens.Preset == null)
				DropError($"NullRef aliens {nameof(ShipPreset)}", ref error);
			if (_asteroids.Prefab == null)
				DropError($"NullRef asteroids {nameof(AsteroidBehaviour)}", ref error);
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
