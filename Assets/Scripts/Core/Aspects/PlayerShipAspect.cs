using Asteroids.Core.Datas;

using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public class PlayerShipAspect : ShipAspect
	{
		//todo move in EngineCore?
		public readonly struct LaserVisual
		{
			public readonly float3 Start;
			public readonly float3 End;
			public readonly float Duration;

			public LaserVisual(float3 start, float3 end, float duration)
			{
				(Start, End, Duration) = (start, end, duration);
			}
		}

		private ShipLaser _laser;

		private float? _laserReload;
		private int _laserCharges;
		private float _laserVisualization;

		public ref ShipLaser Laser => ref _laser;

		public ref float? LaserReload => ref _laserReload;
		public ref int LaserCharges => ref _laserCharges;
		
		public LaserVisual LaserVisualization { get; internal set; }

		public PlayerShipAspect(CollisionData collider, ShipMobility mobility, 
			ShipWeapon weapon, ShipLaser laser) 
			: base(collider, mobility, weapon)
		{
			Laser = laser;
			LaserCharges = laser.MaxCharges;
		}

		public override Aspect Clone()
		{
			return new PlayerShipAspect(Collider, Mobility, Weapon, _laser);
		}
	}
}
