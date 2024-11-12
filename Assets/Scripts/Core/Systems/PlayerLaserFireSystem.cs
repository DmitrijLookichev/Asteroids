using Asteroids.Core.Aspects;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Обработка выстрела и коллизий лазера
	/// </summary>
	public class PlayerLaserFireSystem : BaseSystem<ICoreContainer>
	{
		public PlayerLaserFireSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			var player = Container.Player;
			ref var laser = ref player.Laser;

			if (player.LaserCharges == 0) return;
			if (!player.Input.Get(Datas.ShipInput.Values.Laser)) return;

			ref var transform = ref Container.Player.Transform;
			//Max length in screen
			var distance = math.length(Container.Screen.Min - Container.Screen.Max);

			var offset = math.rotate(transform.rot, player.Weapon.WeaponOffset);
			var startPoint = transform.pos + offset;
			var endPoint = startPoint + math.mul(transform.rot, math.up()) * distance;

			CalcLaserCollision(in startPoint, in endPoint, Container.Aspects.Aliens());
			CalcLaserCollision(in startPoint, in endPoint, Container.Aspects.Asteroids());

			//Update stats
			--player.LaserCharges;
			player.LaserVisualization = new PlayerShipAspect
				.LaserVisual(startPoint, endPoint, time + player.Laser.VisualDuration);
			Container.Aspects.ConfirmChanged();
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
					//for create small asteroids
					if (aspect.Type is ObjectType.BigAsteroid)
						Container.Data.SmallAsteroids.Push(center);
				}
			}
		}
	}
}
