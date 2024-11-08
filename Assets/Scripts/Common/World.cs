using Asteroids.Common.InSystems;
using Asteroids.Common.Objects;
using Asteroids.Common.OutSystems;
using Asteroids.Common.Presets;
using Asteroids.Core;
using Asteroids.Core.Systems;

using System;
using Unity.Profiling;
using UnityEngine;

namespace Asteroids.Common
{
	public class World : IDisposable
    {
		private readonly ProfilerMarker _inMarker = new ("GameLogic.OnInUpdate");
		private readonly ProfilerMarker _logicMarker = new ("GameLogic.OnLogicUpdate");
		private readonly ProfilerMarker _outMarker = new ("GameLogic.OnOutUpdate");

		private readonly ISystem[] _inSystem;
        private readonly ISystem[] _logicSystem;
        private readonly ISystem[] _outSystem;

		public World((ShipBehaviour Prefab, ShipPreset Preset) player,
			(ShipBehaviour Prefab, ShipPreset Preset) alien) 
        {
			var container = new Container(player, alien);

			_inSystem = new ISystem[]
		    {
                new InPlayerSystem(container),
		    };
            _logicSystem = new ISystem[]
		    {
				new PlayerVelocitySystem(container),
				new PlayerTransformSystem(container),
		    };

			_outSystem = new ISystem[]
		    {
				new OutPlayerSystem(container),

			};
		}

        public void OnUpdate(float time, float delta)
        {
			if (Mathf.Approximately(delta, .0f)) return;
			void callUpdate(ISystem[] systems)
			{
				for(int i = 0, iMax = systems.Length; i < iMax; i++)
					systems[i].OnUpdate(time, delta);
			}

			using (_inMarker.Auto())
				callUpdate(_inSystem);

			using (_logicMarker.Auto())
				callUpdate(_logicSystem);

			using (_outMarker.Auto())
				callUpdate(_outSystem);

			PrintLogs();
		}

		public void Dispose()
		{
            void disposeSystems(ISystem[] systems)
            {
                for(int i = 0, iMax = systems.Length; i < iMax; i++)
                    if (systems[i] is IDisposable disposable)
                        disposable.Dispose();
            }

            disposeSystems(_inSystem);
            disposeSystems(_logicSystem);
            disposeSystems(_outSystem);
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
