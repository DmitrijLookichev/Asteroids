﻿using Asteroids.Core.Aspects;

using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	public class AlienInputSystem : BaseSystem<ICoreContainer>
	{
		public AlienInputSystem(ICoreContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			var target = Container.Player.Transform.pos;
			foreach(ShipAspect aspect in Container.Aspects.Aliens())
			{
				ref var transform = ref aspect.Transform;
				transform.rot = quaternion.LookRotation(
					math.normalize(transform.pos - target), -math.forward());
			}
		}
	}
}