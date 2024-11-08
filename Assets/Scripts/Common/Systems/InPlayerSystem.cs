using Asteroids.Core;
using Asteroids.Core.Datas;
using System;

namespace Asteroids.Common.InSystems
{
	internal class InPlayerSystem : BaseSystem<ICommonContainer>, IDisposable
	{
		private PlayerControls _controls;

		public InPlayerSystem(ICommonContainer container) : base(container) 
		{
			_controls = new PlayerControls();
			_controls.Ship.Enable();
		}

		public override void OnUpdate(in float time, in float delta)
        {
			ref var input = ref Container.PlayerAspect.Input;

			input.Rotate = _controls.Ship.Rotate.ReadValue<float>();
			input.Set(ShipInput.Values.Acceleration, _controls.Ship.Acceleration.IsPressed());
			input.Set(ShipInput.Values.Fire, _controls.Ship.Fire.IsPressed());
			input.Set(ShipInput.Values.Laser, _controls.Ship.Laser.IsPressed());
        }

		public void Dispose()
		{
			_controls.Ship.Disable();
			_controls.Dispose();
		}
	}
}
