using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Перемещение снарядов и астеройдов
	/// </summary>
	public class ColliderTransformSystem : BaseSystem<ICoreContainer>
	{
		public ColliderTransformSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			foreach(ColliderAspect collider in Container.Aspects.WithoutShips())
			{
				ref var transform = ref collider.Transform;
				var velocity = math.rotate(transform.rot, math.up());
				transform.pos += velocity * (delta * collider.Speed);
			}
		}
	}
}
