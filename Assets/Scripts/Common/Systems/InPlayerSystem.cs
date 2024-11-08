using Asteroids.Core;
using Asteroids.Core.Aspects;
using Asteroids.Core.Datas;

using System;

namespace Asteroids.Common.InSystems
{
	internal class InPlayerSystem : ISystem, IDisposable
	{
        private readonly ShipAspect _player;
		private PlayerControls _controls;

		public InPlayerSystem(ShipAspect player)
		{
			_player = player;
			_controls.Ship.Enable();
		}

		public void OnUpdate(in float time, in float delta)
        {
			var input = _player.Input;

			input.Rotate = _controls.Ship.Rotate.ReadValue<float>();
			input.Set(ShipInput.Values.Acceleration, _controls.Ship.Acceleration.IsPressed());
			input.Set(ShipInput.Values.Fire, _controls.Ship.Fire.IsPressed());
			input.Set(ShipInput.Values.Laser, _controls.Ship.Laser.IsPressed());

			_player.Input = input;
        }

		public void Dispose()
		{
			_controls.Ship.Disable();
			_controls.Dispose();
		}
	}
}
