using Asteroids.Common.InSystems;
using Asteroids.Common.Actors;
using Asteroids.Common.OutSystems;
using Asteroids.Common.Presets;
using Asteroids.Common.Stores;
using Asteroids.Core;
using Asteroids.Core.Systems;

using System;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace Asteroids.Common
{
	public class World : IDisposable
    {
		private readonly ProfilerMarker _marker = new ("Systems.OnUpdate");

        private readonly ISystem[] _systems;

		public World(SceneSettings settings) 
        {
			var container = new Container(settings);

            _systems = new ISystem[]
		    {
				//Inhale data systems (Inputs)
				new InPlayerSystem(container),
				//---------------------------------------
				//GameLogic (without UnityEngine) systems
				new PlayerVelocitySystem(container),
				new PlayerTransformSystem(container),
				new PlayerFireSystem(container),
				new ColliderLifetimeSystem(container),
				new ColliderMoveSystem(container),
				new ColliderCollisionSystem(container),
				//---------------------------------------
				//Exhale data systems (Outputs)
				new OutPlayerSystem(container),
				new RendererSystem(container),
			};
		}

        public void OnUpdate(float time, float delta)
        {
			if (Mathf.Approximately(delta, .0f)) return;
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
