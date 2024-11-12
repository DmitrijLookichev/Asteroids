using Asteroids.Core.Aspects;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Расчет времени жизни астеройдов и снарядов
	/// </summary>
	public class ColliderLifetimeSystem : BaseSystem<ICoreContainer>
	{
		public ColliderLifetimeSystem(ICoreContainer container) : base(container){}

		public override void OnUpdate(in float time, in float delta)
		{
			//todo add asteroidsAspects
			foreach (ColliderAspect collider in Container.Aspects.WithoutShips())
			{
				if (collider.TimeToDie > time) continue;
				Container.Aspects.ReturnAspect(collider);
			}
			Container.Aspects.ConfirmChanged();
		}
	}
}
