namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Перемещение аспектов при выходе за экран
	/// </summary>
	public class AspectTeleportSystem : BaseSystem<ICoreContainer>
	{
		public AspectTeleportSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			ref var rect = ref Container.Screen;
			var xSwift = rect.Max.x - rect.Min.x;
			var ySwift = rect.Max.y - rect.Min.y;
			foreach(var aspect in Container.Aspects.All())
			{
				ref var pos = ref aspect.Transform.pos;
				if (pos.x < rect.Min.x) pos.x += xSwift;
				else if (pos.x > rect.Max.x) pos.x -= xSwift;

				if (pos.y < rect.Min.y) pos.y += ySwift;
				else if (pos.y > rect.Max.y) pos.y -= ySwift;
			}
		}
	}
}
