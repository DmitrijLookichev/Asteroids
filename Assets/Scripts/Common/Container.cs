using Asteroids.Common.Objects;
using Asteroids.Common.Presets;
using Asteroids.Core;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;
using Unity.Mathematics;

using UnityEngine;

namespace Asteroids.Common
{
	internal class Container : ICommonContainer, ICoreContainer
	{
		private uint _identity = 0u;
		private ShipAspect _player;


		public ref ShipAspect PlayerAspect => ref _player;
		public ShipBehaviour PlayerBehaviour { get; }

		//public Dictionary<uint, ShipAspect> Aliens;
		//public Dictionary<uint, ShipBehaviour> AliensMono;


		public Container((ShipBehaviour Prefab, ShipPreset Preset) player,
			(ShipBehaviour Prefab, ShipPreset Preset) alien)
		{
			var instance = player.Prefab;
			_player = CreateShip(player.Preset, ref instance);
			PlayerBehaviour = instance;
		}

		//todo move? this is pure data
		//todo create Pools for asteroids and aliens
		//todo maybe create SpawnSystem for player? (and for aliens)
		public ShipAspect CreateShip(ShipPreset preset, ref ShipBehaviour behaviour)
		{
			var mobility = new ShipMobility(math.radians(preset.RotationSpeed),
				preset.Acceleration, preset.Deceleration, preset.MaxVelocity);
			var aspect = new ShipAspect(mobility, (byte)preset.Lifes,
				preset.LaserReload, new ShipInput());

			behaviour = Object.Instantiate(behaviour);
			aspect.Identity = behaviour.Identity = ++_identity;
			//todo set player in center screen and sync this
			return aspect;
		}
	}
}
