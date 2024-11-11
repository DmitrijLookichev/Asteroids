using Asteroids.Common.Stores;
using Asteroids.Core;
using System;
using Unity.Mathematics;
using UnityEngine;

namespace Asteroids.Common.Systems
{
	internal class PresentationUISystem : BaseSystem<ICommonContainer>
	{
		public PresentationUISystem(ICommonContainer container) : base(container) {}

		public override void OnUpdate(in float time, in float delta)
		{
			var player = Container.Player;
			ref var transform = ref player.Transform;
			var presentation = Container.Presentation;
			presentation.Coordinates.text = $"X: {Math.Round(transform.pos.x, 2)} Y: {Math.Round(transform.pos.y, 2)}";
			presentation.Angle.text = $"< {math.round(((Quaternion)transform.rot).eulerAngles.z)}°";
			presentation.Speed.text = $"U: {Math.Round(math.length(player.Velocity), 1)}";
			presentation.LaserCount.text = $"x{player.LaserCharges}";

			var last = player.LaserReload is null
				?  0f : player.LaserReload.Value - time;
			presentation.LaserFill.fillAmount = 1f - last / player.Laser.LaserReload;
			presentation.LaserReload.text = Mathf.Max(Mathf.RoundToInt(last), 0).ToString();
			presentation.Score.text = Container.Data.Score.ToString();
		}
	}
}
