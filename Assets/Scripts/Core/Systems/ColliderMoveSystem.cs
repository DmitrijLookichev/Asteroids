using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class ColliderMoveSystem : BaseSystem<ICoreContainer>
	{
		public ColliderMoveSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			foreach(var collider in Container.ProjectileAspects)
			{
				ref var transform = ref collider.Transform;
				var velocity = math.rotate(transform.rot, math.up());
				transform.pos += velocity * (delta * collider.Speed);
			}
		}
	}
}
