using Asteroids.Core.Datas;
using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	//todo struct in Container??
	public class ShipAspect : Aspect
	{
		private ShipMobility _mobility;
		private ShipWeapon _weapon;
		private ShipInput _input;

		private float3 _velocity;
		private float _fireReload;
		private float _laserReload;

		//Components
		//todo нужно всего два экземпляра в проекте - для игркоа и для пришельцев
		public ref ShipMobility Mobility => ref _mobility;
		public ref ShipWeapon Weapon => ref _weapon;
		public ref ShipInput Input => ref _input;

		//Datas
		public ref float3 Velocity => ref _velocity;
		public ref float FireReload => ref _fireReload;
		public ref float LaserReload => ref _laserReload;

		public ShipAspect(CollisionData collider, ShipMobility mobility, ShipWeapon weapon) : base(collider)
		{
			(Mobility, Weapon, Input)
				= (mobility, weapon, new ShipInput());
		}

		public override Aspect Clone()
		{
			return new ShipAspect(Collider, _mobility, _weapon);
		}
	}
}
