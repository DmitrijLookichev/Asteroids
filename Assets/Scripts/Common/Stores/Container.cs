using Asteroids.Common.Actors;
using Asteroids.Common.Presets;
using Asteroids.Core;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;
using Unity.Mathematics;

using UnityEngine;

namespace Asteroids.Common.Stores
{
	internal class Container : ICommonContainer, ICoreContainer
	{
		private ShipAspect _player;
		//todo think about: в чем разница между снарядом и астеройдом глобальная? Только визуал и физ слой
		private ObjectPool<ColliderActor, ColliderAspect> _projectilePool;
		private ObjectPool<ColliderActor, ColliderAspect> _asteroidPool;
		private ObjectPool<ShipActor, ShipAspect> _alienPool;


		public ref ShipAspect PlayerAspect => ref _player;
		public ShipActor PlayerBehaviour { get; }

		public ICorePool<ColliderAspect> ProjectileAspects => _projectilePool;
		public ICommonPool<ColliderActor> ProjectileBehaviours => _projectilePool;

		//public Dictionary<uint, ShipAspect> Aliens;
		//public Dictionary<uint, ShipBehaviour> AliensMono;


		public Container(SceneSettings settings)
		{
			var instance = settings.Player.Prefab;
			_player = CreateShip(settings.Player.Preset, ref instance);
			PlayerBehaviour = instance;

			var colliderAspect = new ColliderAspect(
				settings.Projectile.Preset.MoveSpeed, 
				settings.Projectile.Preset.Lifetime);
			_projectilePool = new ObjectPool<ColliderActor, ColliderAspect>(
				settings.Projectile.Prefab, colliderAspect, 32);
			//_asteroidPool = new ObjectPool<ColliderActor, ColliderAspect>();
			//_alienPool = new ObjectPool<ShipActor, ShipAspect>();
		}

		//todo move? this is pure data
		//todo create Pools for asteroids and aliens
		//todo maybe create SpawnSystem for player? (and for aliens)
		public ShipAspect CreateShip(ShipPreset preset, ref ShipActor behaviour)
		{
			var mobility = new ShipMobility(math.radians(preset.RotationSpeed),
				preset.Acceleration, preset.Deceleration, preset.MaxVelocity);
			var weapon = new ShipWeapon(behaviour.FireOffset, preset.FireReload, preset.LaserReload);
			var aspect = new ShipAspect(mobility, weapon);

			behaviour = Object.Instantiate(behaviour);
			//todo ??? aspect.Identity = behaviour.Identity = ++_identity;
			//todo set player in center screen and sync this
			return aspect;
		}
	}
}
