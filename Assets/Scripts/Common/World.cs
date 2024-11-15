using Asteroids.Common.Systems;
using Asteroids.Common.Stores;
using Asteroids.Core;
using Asteroids.Core.Systems;

using System;
using Unity.Profiling;
using UnityEngine;
using Asteroids.Common.Presentation;

namespace Asteroids.Common
{
	/// <summary>
	/// GameLogic host
	/// </summary>
	public class World : IDisposable
    {
		private readonly ProfilerMarker _marker = new ("Systems.OnUpdate");
        private readonly ISystem[] _systems;
		//time offset in current level
		private float _levelTime;

		public World(SceneSettings settings, PresentationController presentation) 
        {
			var container = new Container(settings, presentation);
			_levelTime = Time.time;
			_systems = new ISystem[]
			{
				//Inhale data systems (Inputs)
				new InsertionCameraSystem(container),
				new InsertionPlayerInputSystem(container),
				//---------------------------------------
				//GameLogic (without UnityEngine) systems
				new ColliderLifetimeSystem(container),
				new SmallAsteroidSpawnSystem(container),
				new AlienAndBigAsteroidSpawnSystem(container),
				new AlienInputSystem(container),
				new ShipWeaponSystem(container),
				new PlayerLaserRenewalSystem(container),
				new PlayerLaserFireSystem(container),
				new ShipVelocitySystem(container),
				new ShipTransformSystem(container),
				new ColliderTransformSystem(container),
				new AspectTeleportSystem(container),
				new AspectCollisionSystem(container),
				//---------------------------------------
				//Exhale data systems (Outputs)
				new PresentationGameOverSystem(container),
				new PresentationActorTransformSystem(container),
				new PresentationPlayerLaserSystem(container),
				new PresentationUISystem(container),
			};
		}

        public void OnManualUpdate()
        {
			var delta = Time.deltaTime;
			if (Mathf.Approximately(delta, .0f)) return;

			var time = Time.time - _levelTime;
			using (_marker.Auto())
			{
				for (int i = 0, iMax = _systems.Length; i < iMax; i++)
					_systems[i].OnUpdate(time, delta);
			}

			PrintLogs();
		}

		public void Dispose()
		{
			for (int i = 0, iMax = _systems.Length; i < iMax; i++)
				if (_systems[i] is IDisposable disposable)
					disposable.Dispose();
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private void PrintLogs()
		{
#if UNITY_EDITOR
			foreach (var log in DebugUtility.Queue)
			{
				switch (log.Type)
				{
					case DebugUtility.LogType.Log:
						Debug.Log(log.Message);
						break;
					case DebugUtility.LogType.Warning:
						Debug.LogWarning(log.Message);
						break;
					case DebugUtility.LogType.Error:
						Debug.LogError(log.Message);
						break;
				}
			}
			DebugUtility.Queue.Clear();
#endif
		}
	}
}
