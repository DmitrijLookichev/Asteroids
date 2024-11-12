using Asteroids.Core.Aspects;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Система расчета всех разрешенных коллизий аспектов
	/// </summary>
	public class AspectCollisionSystem : BaseSystem<ICoreContainer>
	{
		private float _time;

		public AspectCollisionSystem(ICoreContainer container) : base(container) {}

		public override void OnUpdate(in float time, in float delta)
		{
			_time = time;
			foreach (var playerProjectile in Container.Aspects.PlayerProjectiles())
			{
				foreach(var asteroid in Container.Aspects.Asteroids())
					CheckCollision(playerProjectile, asteroid);
				foreach (var alien in Container.Aspects.Aliens())
					CheckCollision(playerProjectile, alien);
			}
			Container.Aspects.ConfirmChanged();

			var player = Container.Player;
			foreach (var aspect in Container.Aspects.Asteroids())
				CheckCollision(player, aspect);
			foreach (var aspect in Container.Aspects.AlienProjectiles())
				CheckCollision(player, aspect);
			Container.Aspects.ConfirmChanged();
		}

		private void CheckCollision(Aspect self, Aspect other)
		{
			var type = self.Collider.Type;
			var selfR = self.Collider.Radius;
			var selfPosition = self.Transform.pos;

			var otherPosition = other.Transform.pos;
			var direction = otherPosition - selfPosition;
			var sumR = selfR + other.Collider.Radius;
			//Check collision
			if (math.lengthsq(direction) <= sumR * sumR)
			{
				DebugUtility.AddLog($"<b>[Collision]</b>: {type} & {other.Collider.Type}!");
				ConfirmDestroyResult(type, self);
				ConfirmDestroyResult(other.Collider.Type, other);
			}
		}

		private void ConfirmDestroyResult(in ObjectType type, Aspect aspect)
		{
			switch (type)
			{
				//If Player - GameOver
				case ObjectType.Player:
					//Force set MenuPause
					((ShipAspect)aspect).Input.Set(Datas.ShipInput.Values.Pause, true);
					break;
				//If Asteroid - remove and create smalls
				case ObjectType.BigAsteroid:
					Container.Data.SmallAsteroids.Push(aspect.Transform.pos);
					goto case ObjectType.SmallAsteroid;
				//remove
				case ObjectType.SmallAsteroid:
				case ObjectType.Alien:
					Container.Data.AddScore(aspect.Type);
					goto case ObjectType.ProjectilePlayer;
				case ObjectType.ProjectilePlayer:
				case ObjectType.ProjectileAlien:
					Container.Aspects.ReturnAspect(aspect);
					break;
			}
		}		
	}
}
