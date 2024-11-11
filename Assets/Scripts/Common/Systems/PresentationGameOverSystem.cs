using Asteroids.Common.Stores;
using Asteroids.Core;

namespace Asteroids.Common.Systems
{
	internal class PresentationGameOverSystem : BaseSystem<ICommonContainer>
	{
		public PresentationGameOverSystem(ICommonContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			if(Container.Player.Input.Get(Core.Datas.ShipInput.Values.Pause))
			{
				DebugUtility.AddError("Dead!");
			}
		}
	}
}
