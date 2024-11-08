using Asteroids.Core.Aspects;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
    public class PlayerVelocitySystem : ISystem
    {
		private readonly ShipAspect _player;

		public PlayerVelocitySystem(ShipAspect player)
		{
			_player = player;
		}
		public void OnUpdate(in float time, in float delta)
		{
			ref var input = ref _player.Input;
			ref var velocity = ref _player.Velocity;
			var forward = math.mul(_player.Transform.rot.value, new float3(0, 0, 1));

			velocity = input.Get(Datas.ShipInput.Values.Acceleration)
				//add acceleration
				? velocity + forward * _player.Mobility.Acceleration
				//use deceleration
				: velocity - forward * _player.Mobility.Deceleration;

			velocity = mathU.ClampMagnitude(velocity, _player.Mobility.MaxVelocity);
		}
    }
}
