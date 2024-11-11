using Asteroids.Core.Aspects;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class ShipFireSystem : BaseSystem<ICoreContainer>
	{
		public ShipFireSystem(ICoreContainer container) : base(container) { }

		public override void OnUpdate(in float time, in float delta)
		{
			SpawnProjectile(Container.Player, ObjectType.ProjectilePlayer, in time);

			foreach (ShipAspect ship in Container.Aspects.Aliens())
				SpawnProjectile(ship, ObjectType.ProjectileAlien, in time);
		}

		private void SpawnProjectile(ShipAspect owner, in ObjectType type, in float time)
		{
			if (owner.Input.Get(Datas.ShipInput.Values.Fire)
					&& owner.FireReload <= time)
			{
				//spawn ProjectileAspect
				ColliderAspect projectile = Container.Aspects.GetAspect<ColliderAspect>(type);
				ref var transform = ref projectile.Transform;
				//Translate
				var offset = math.rotate(owner.Transform.rot, owner.Weapon.WeaponOffset);
				transform.pos = owner.Transform.pos + offset;
				transform.rot = owner.Transform.rot;
				//Set time to die
				projectile.TimeToDie = time + projectile.Lifetime;
				//Update reload
				owner.FireReload = time + owner.Weapon.FireReload;
			}
		}
	}
}
