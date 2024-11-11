namespace Asteroids.Core.Systems
{
	public class AspectTeleportSystem : BaseSystem<ICoreContainer>
	{
		public AspectTeleportSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			ref var rect = ref Container.Screen;
			var xSwift = rect.xMax - rect.xMin;
			var ySwift = rect.yMax - rect.yMin;
			foreach(var aspect in Container.Aspects.All())
			{
				ref var pos = ref aspect.Transform.pos;
				if (pos.x < rect.xMin) pos.x += xSwift;
				else if (pos.x > rect.xMax) pos.x -= xSwift;

				if (pos.y < rect.yMin) pos.y += ySwift;
				else if (pos.y > rect.yMax) pos.y -= ySwift;
			}
		}
	}
}
