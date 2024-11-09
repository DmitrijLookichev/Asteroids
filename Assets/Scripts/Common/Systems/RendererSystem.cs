using Asteroids.Common.Actors;
using Asteroids.Common.Stores;
using Asteroids.Core;
using Asteroids.Core.Aspects;

using UnityEngine;

namespace Asteroids.Common.OutSystems
{
	internal class RendererSystem : BaseSystem<ICommonContainer>
	{
		public RendererSystem(ICommonContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			foreach(var aspect in Container.ProjectileAspects)
			{
				var actor = Container.ProjectileBehaviours.Temp_GetActor(aspect.Identity);
				Translate(aspect, actor);
			}
			//todo add Asteroids and ALien?
		}

		private void Translate(IAspect aspect, ColliderActor actor)
		{
			var position = (Vector3)aspect.Transform.pos;
			var rotation = (Quaternion)aspect.Transform.rot;

			actor.transform.SetPositionAndRotation(position, rotation);
		}
	}
}
