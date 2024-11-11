using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class ShipTransformSystem : BaseSystem<ICoreContainer>
	{
		public ShipTransformSystem(ICoreContainer container) : base(container) { }

		public override void OnUpdate(in float time, in float delta)
		{
			foreach (ShipAspect ship in Container.Aspects.Ships())
			{
				//Translate
				ref var velocity = ref ship.Velocity;
				ref var transform = ref ship.Transform;
				transform.pos += velocity * delta;
				//Rotate
				var rotate = ship.Input.Rotate * ship.Mobility.RotationSpeed * delta;
				transform.rot = math.mul(ship.Transform.rot, quaternion.Euler(0f, 0f, -rotate));
			}
		}
	}
}