using Asteroids.Common.Stores;
using Asteroids.Core;

namespace Asteroids.Common.Systems
{
	internal class PresentationPlayerLaserSystem : BaseSystem<ICommonContainer>
	{
		public PresentationPlayerLaserSystem(ICommonContainer container) : base(container) {}

		public override void OnUpdate(in float time, in float delta)
		{
			var renderer = Container.PlayerActor.LineRenderer;
			var laserData = Container.Player.LaserVisualization;
			if (laserData.Duration > time)
			{
				renderer.positionCount = 2;
				renderer.SetPosition(0, laserData.Start);
				renderer.SetPosition(1, laserData.End);
			}
			else if (renderer.positionCount > 0)
				renderer.positionCount = 0;
		}
	}
}
