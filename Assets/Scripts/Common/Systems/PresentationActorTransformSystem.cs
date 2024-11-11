using Asteroids.Common.Stores;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Common.Systems
{
	internal class PresentationActorTransformSystem : BaseSystem<ICommonContainer>
	{
		public PresentationActorTransformSystem(ICommonContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			foreach(var aspect in Container.Aspects.All())
			{
				var actor = Container.Actors.GetActor(aspect);

				var position = (Vector3)aspect.Transform.pos;
				var rotation = (Quaternion)aspect.Transform.rot;

				actor.transform.SetPositionAndRotation(position, rotation);
			}
		}
	}
}
