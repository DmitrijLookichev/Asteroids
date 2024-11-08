using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class PlayerTransformSystem : ISystem
	{
		private readonly ShipAspect _player;

		public PlayerTransformSystem(ShipAspect player)
		{
			_player = player;
		}

		public void OnUpdate(in float time, in float delta)
		{
			//Translate
			ref var velocity = ref _player.Velocity;
			ref var transform = ref _player.Transform;
			transform.pos += velocity * delta;
			//Rotate
			var rotate = _player.Input.Rotate * _player.Mobility.RotationSpeed * delta;
			transform.rot = math.mul(_player.Transform.rot, 
				quaternion.Euler(0f, 0f, rotate));
		}
	}
}