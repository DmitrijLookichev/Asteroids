using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	//todo можно залочить стрельбу тарелкам и обрабатывать их и здесь же
	//todo фактически, для контроля бота нужно создать просто свою систему обработки инпута
	public class PlayerFireSystem : BaseSystem<ICoreContainer>
	{
		public PlayerFireSystem(ICoreContainer container) : base(container) { }

		public override void OnUpdate(in float time, in float delta)
		{
			ref var player = ref Container.PlayerAspect;
			//Need and can shooting
			if(player.Input.Get(Datas.ShipInput.Values.Fire)
				&& player.FireReload <= time)
			{
				//spawn ProjectileAspect
				ColliderAspect projectile = Container.ProjectileAspects.Temp_GetAspect();
				ref var transform = ref projectile.Transform;
				//Translate
				var offset = math.rotate(player.Transform.rot, player.Weapon.WeaponOffset);
				transform.pos = player.Transform.pos + offset;
				transform.rot = player.Transform.rot;
				//Set time to die
				projectile.TimeToDie = time + projectile.Lifetime;
				//Update reload
				player.FireReload = time + player.Weapon.FireReload;
			}
		}
	}
}
