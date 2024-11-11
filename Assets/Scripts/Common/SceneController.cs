using Asteroids.Common.Actors;
using Asteroids.Common.Presentation;
using Asteroids.Common.Presets;

using UnityEngine;
namespace Asteroids.Common
{
    public class SceneController : MonoBehaviour
    {
		private World _world;

		[SerializeField]
		private PresentationController _presentation;
		[SerializeField]
		private SceneSettings _settings;

		private void Awake()
		{
#if UNITY_EDITOR
			if (CheckNullRefs()) return;
#endif

			_world = new World(_settings, _presentation);

			//UnityEditorInternal.InternalEditorUtility
			
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

		private bool CheckNullRefs()
		{
			var error = false;
			if(_settings == null)
				DropError(nameof(SceneSettings), ref error);
			if (_settings.Player.Prefab == null
				|| _settings.Alien.Prefab == null)
				DropError(nameof(ShipActor), ref error);
			if (_settings.Player.Preset == null
				|| _settings.Alien.Preset == null)
				DropError(nameof(ShipActorPreset), ref error);
			if (_settings.ProjectilePlayer.Prefab == null
				|| _settings.ProjectileAlien.Prefab == null
				|| _settings.BigAsteroid.Prefab == null
				|| _settings.SmallAsteroid.Prefab == null)
				DropError(nameof(Actor), ref error);
			if (_settings.ProjectilePlayer.Preset == null
				|| _settings.ProjectileAlien.Preset == null
				|| _settings.BigAsteroid.Preset == null
				|| _settings.SmallAsteroid.Preset == null)
				DropError(nameof(ColliderPreset), ref error);
			return error;
		}

		private void DropError(string message, ref bool error)
		{
			UnityEditor.EditorApplication.isPlaying = false;
			Debug.LogError($"NullRef <b>{message}</b>", this);
			error = true;
		}
#endif
	}
}
