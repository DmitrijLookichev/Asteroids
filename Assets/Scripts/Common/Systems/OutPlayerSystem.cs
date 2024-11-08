using Asteroids.Core;
using Asteroids.Core.Aspects;
using UnityEngine;

namespace Asteroids.Common.OutSystems
{
	internal class OutPlayerSystem : ISystem
	{
		private readonly ShipAspect _player;
		//todo add in construct
		private readonly Transform _presentation;
		//todo add UI update???

		public OutPlayerSystem(ShipAspect player)
		{
			_player = player;
		}

		public void OnUpdate(in float time, in float delta)
		{
			//update transformation
			ref var transform = ref _player.Transform;
			_presentation.SetPositionAndRotation(transform.pos, transform.rot);
		}
	}
}

