using Asteroids.Common.Actors;
using Asteroids.Common.Presentation;
using Asteroids.Core;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;
using Unity.Mathematics;

using static Asteroids.Common.SceneSettings;

namespace Asteroids.Common.Stores
{
	internal class Container : ICommonContainer, ICoreContainer
	{
		private ObjectPool _pool;
		private GameData _gameData;
		private Core.Rect _rect;

		public IActorPool Actors => _pool;
		public ShipActor PlayerActor { get; }
		public IAspectPool Aspects => _pool;
		public ShipAspect Player { get; }
		public ref GameData Data => ref _gameData;
		public ref Core.Rect Screen => ref _rect;
		public PresentationController Presentation { get; }

		

		public Container(SceneSettings settings, PresentationController presentation)
		{
			_pool = new ObjectPool();
			//todo magic value
			_gameData = new GameData(new int[] {1, 1, 1, 1, 1, 1}, 
				settings.SpawnSmallAsteroids,
				settings.AsteroidSpawnInterval, 
				settings.AlienSpawnInterval);
			Presentation = presentation;

			//Init Pool data
			//todo magic numbers?
			_pool.AddPrefab(ObjectType.Player, settings.Player.Prefab, 
				CreateAspect(settings.Player), 1);
			_pool.AddPrefab(ObjectType.Alien, settings.Alien.Prefab,
				CreateAspect(settings.Alien), 4);
			_pool.AddPrefab(ObjectType.BigAsteroid, settings.BigAsteroid.Prefab,
				CreateAspect(settings.BigAsteroid), 8);
			_pool.AddPrefab(ObjectType.SmallAsteroid, settings.SmallAsteroid.Prefab,
				CreateAspect(settings.SmallAsteroid), 32);
			_pool.AddPrefab(ObjectType.ProjectilePlayer, settings.ProjectilePlayer.Prefab,
				CreateAspect(settings.ProjectilePlayer), 16);
			_pool.AddPrefab(ObjectType.ProjectileAlien, settings.ProjectileAlien.Prefab,
				CreateAspect(settings.ProjectileAlien), 8);

			//for short getter
			Player = _pool.GetAspect<ShipAspect>(ObjectType.Player);
			_pool.ConfirmChanged();
			PlayerActor = _pool.GetActor(Player) as ShipActor;
		}

		private ShipAspect CreateAspect(ShipSettings settings)
		{
			var (actor, preset) = (settings.Prefab, settings.Preset);
			var mobility = new ShipMobility(preset.RotationSpeed,
				preset.Acceleration, preset.Deceleration, preset.MaxVelocity);
			var weapon = new ShipWeapon(actor.FireOffset, preset.FireReload, preset.LaserReload);

			return new ShipAspect(new CollisionData(actor.Radius, actor.Type), mobility, weapon);
		}

		private ColliderAspect CreateAspect(ColliderSettings settings)
		{
			var (actor, preset) = (settings.Prefab, settings.Preset);
			return new ColliderAspect(
				new CollisionData(actor.Radius, actor.Type),
				preset.MoveSpeed, preset.Lifetime);
		}
	}
}
