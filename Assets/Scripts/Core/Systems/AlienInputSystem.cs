using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Определение направления вращения пришельцев на игрока
	/// </summary>
	public class AlienInputSystem : BaseSystem<ICoreContainer>
	{
		public AlienInputSystem(ICoreContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			var target = Container.Player.Transform.pos;
			foreach(ShipAspect aspect in Container.Aspects.Aliens())
			{
				var up = math.mul(aspect.Transform.rot, math.down());
				var direction = target - aspect.Transform.pos;

				var angle = mathU.SignedAngle(up, direction, math.forward()) / 180f;
				aspect.Input.Rotate = angle;
			}
		}
	}
}
