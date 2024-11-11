using Asteroids.Core.Aspects;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class PlayerLaserSystem : BaseSystem<ICoreContainer>
	{
		public PlayerLaserSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			var player = Container.Player;
			if (!player.Input.Get(Datas.ShipInput.Values.Laser)
				|| player.LaserReload > time) return;

			ref var transform = ref Container.Player.Transform;
			//Max length in screen
			var distance = math.length(
				new float2(Container.Screen.xMin, Container.Screen.yMin) -
				new float2(Container.Screen.xMax, Container.Screen.yMax));

			var startPoint = transform.pos;
			var endPoint = startPoint + math.mul(transform.rot, math.up()) * distance;

			CalcLaserCollision(in startPoint, in endPoint, Container.Aspects.Aliens());
			CalcLaserCollision(in startPoint, in endPoint, Container.Aspects.Asteroids());

			//todo temp magic number
			Container.Data.Laser = (time + 5f, startPoint, endPoint);
			Container.Aspects.ConfirmChanged();

			player.LaserReload = time + player.Weapon.LaserReload;
		}

		private void CalcLaserCollision(in float3 start, in float3 end, IEnumerable<Aspect> aspects)
		{
			foreach (var aspect in aspects)
			{
				var center = aspect.Transform.pos;
				var radiusSqr = aspect.Collider.Radius;
				radiusSqr *= radiusSqr;

				var project = mathU.ProjectPointLine(center, start, end);
				if (math.lengthsq(project - center) < radiusSqr)
				{
					Container.Aspects.ReturnAspect(aspect);
					Container.Data.AddScore(aspect.Type);
					//todo hit! and draw
					DebugUtility.AddLog("Laser Kill!!");
				}
			}
		}
	}
}
