namespace Asteroids.Core.Systems
{
	public class ColliderLifetimeSystem : BaseSystem<ICoreContainer>
	{
		public ColliderLifetimeSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			//todo add asteroidsAspects
			foreach (var collider in Container.ProjectileAspects)
			{
				if (collider.TimeToDie > time) continue;
				Container.ProjectileAspects.Temp_ReturnAspect(collider);
			}
			//todo temp solution
			Container.ProjectileAspects.Temp_ClearReturnedAspects();
		}
	}
}
