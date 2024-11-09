using Asteroids.Common.Stores;
using Asteroids.Core;

namespace Asteroids.Common.OutSystems
{
	internal class OutPlayerSystem : BaseSystem<ICommonContainer>
	{
		public OutPlayerSystem(ICommonContainer container) : base(container) {}

		public override void OnUpdate(in float time, in float delta)
		{
			//update transformation
			ref var transform = ref Container.PlayerAspect.Transform;

			Container.PlayerBehaviour.transform
				.SetPositionAndRotation(transform.pos, transform.rot);
		}
	}
}

