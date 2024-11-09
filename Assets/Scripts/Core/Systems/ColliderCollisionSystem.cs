using Asteroids.Core.Aspects;

using System.Collections.Generic;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class ColliderCollisionSystem : BaseSystem<ICoreContainer>
	{
		public ColliderCollisionSystem(ICoreContainer container) : base(container) {}

		public override void OnUpdate(in float time, in float delta)
		{
			CheckCollision(Container.PlayerAspect, Container.ProjectileAspects);
		}

		private void CheckCollision(IAspect target, IEnumerable<IAspect> others)
		{
			var type = target.Collider.Type;
			var targetR = target.Collider.Radius;
			var targetPosition = target.Transform.pos;
			foreach (var other in others)
			{
				if (!mathU.Temp_Check(type, other.Collider.Type)) continue;

				var otherPosition = other.Transform.pos;
				var direction = otherPosition - targetPosition;
				var sumR = targetR + other.Collider.Radius;
				//Check collision
				if(math.lengthsq(direction) <= sumR * sumR)
				{
					DebugUtility.AddLog($"Hit: {type} and {other.Collider.Type}!");
					CalculateResult(type, target);
					CalculateResult(other.Collider.Type, other);
				}
			}

			Container.ProjectileAspects.Temp_ClearReturnedAspects();
		}

		private void CalculateResult(in ObjectType type, IAspect aspect)
		{
			switch (type)
			{
				//If Player - GameOver
				case ObjectType.Player:
					break;
				//If Alien - remove
				case ObjectType.Alien:
					break;
				//If Asteroid - remove and create smalls
				case ObjectType.Asteroid:
					break;
				//If Projectile - remove
				case ObjectType.ProjectilePlayer:
				case ObjectType.ProjectileAlien:
					//todo temp
					Container.ProjectileAspects.Temp_ReturnAspect((ColliderAspect)aspect);
					break;
			}
		}
	}
}
