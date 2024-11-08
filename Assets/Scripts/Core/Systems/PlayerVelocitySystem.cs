using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
    public class PlayerVelocitySystem : BaseSystem<ICoreContainer>
	{
		public PlayerVelocitySystem(ICoreContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			ref var player = ref Container.PlayerAspect;

			ref var mobility = ref player.Mobility;
			ref var input = ref player.Input;
			ref var velocity = ref player.Velocity;

			var up = math.mul(player.Transform.rot.value, math.up());

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
