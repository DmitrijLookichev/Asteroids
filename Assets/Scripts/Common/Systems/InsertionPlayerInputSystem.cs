using Asteroids.Common.Stores;
using Asteroids.Core;
using Asteroids.Core.Datas;
using System;

namespace Asteroids.Common.Systems
{
	/// <summary>
	/// Передача в Core пользовательского ввода
	/// </summary>
	internal class InsertionPlayerInputSystem : BaseSystem<ICommonContainer>, IDisposable
	{
		private PlayerControls _controls;

		public InsertionPlayerInputSystem(ICommonContainer container) : base(container) 
		{
			_controls = new PlayerControls();
			_controls.Ship.Enable();
		}

		public override void OnUpdate(in float time, in float delta)
        {
			ref var input = ref Container.Player.Input;

			input.Rotate = _controls.Ship.Rotate.ReadValue<float>();
			input.Set(ShipInput.Values.Acceleration, _controls.Ship.Acceleration.IsPressed());
			input.Set(ShipInput.Values.Fire, _controls.Ship.Fire.IsPressed());
			input.Set(ShipInput.Values.Laser, _controls.Ship.Laser.WasPressedThisFrame());
        }

		public void Dispose()
		{
			_controls.Ship.Disable();
			_controls.Dispose();
		}
	}
}
