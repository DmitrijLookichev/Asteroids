using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class PlayerTransformSystem : BaseSystem<ICoreContainer>
	{
		public PlayerTransformSystem(ICoreContainer container) : base(container) { }

		public override void OnUpdate(in float time, in float delta)
		{
			ref var player = ref Container.PlayerAspect;

			//Translate
			ref var velocity = ref player.Velocity;
			ref var transform = ref player.Transform;
			transform.pos += velocity * delta;
			//Rotate
			var rotate = player.Input.Rotate * player.Mobility.RotationSpeed * delta;
			transform.rot = math.mul(player.Transform.rot, quaternion.Euler(0f, 0f, -rotate));
		}
	}
}