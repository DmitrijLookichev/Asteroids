using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
    public class ShipVelocitySystem : BaseSystem<ICoreContainer>
	{
		public ShipVelocitySystem(ICoreContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			foreach (ShipAspect ship in Container.Aspects.Ships())
			{
				ref var mobility = ref ship.Mobility;
				ref var input = ref ship.Input;
				ref var velocity = ref ship.Velocity;

				var up = math.mul(ship.Transform.rot.value, math.up());

				//add acceleration
				if (input.Get(Datas.ShipInput.Values.Acceleration))
				{
					velocity += up * mobility.Acceleration;
				}
				//without movement
				else if (mathU.Approximately(math.lengthsq(velocity), 0f))
					return;
				//use deceleration
				else
				{
					velocity = math.lerp(velocity, float3.zero, delta * mobility.Deceleration);
				}

				velocity = mathU.ClampMagnitude(velocity, mobility.MaxVelocity);
			}
		}
	}
}
