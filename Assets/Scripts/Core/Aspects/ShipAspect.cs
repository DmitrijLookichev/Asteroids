using Asteroids.Core.Datas;
using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	//todo struct in Container??
	public class ShipAspect : IAspect
	{
		private CollisionData _collider;
		private RigidTransform _transform;
		private ShipMobility _mobility;
		private ShipWeapon _weapon;
		private ShipInput _input;

		private float3 _velocity;
		private float _fireReload;

		public uint Identity { get; set; }

		//Components
		public ref CollisionData Collider => ref _collider;
		public ref RigidTransform Transform { get => ref _transform; }
		public ref ShipMobility Mobility { get => ref _mobility; }
		public ref ShipWeapon Weapon { get => ref _weapon; }
		public ref ShipInput Input { get => ref _input; }

		//Datas
		public ref float3 Velocity { get => ref _velocity; }
		public ref float FireReload { get => ref _fireReload; }

		public ShipAspect(CollisionData collider, ShipMobility mobility, ShipWeapon weapon)
		{
			_collider = collider;
			(Transform, Mobility, Weapon, Input)
				= (RigidTransform.identity, mobility, weapon, new ShipInput());
		}

		[System.Obsolete]//todo
		public void Teleport(float3 pos, quaternion rot)
		{
			(_transform.pos, _transform.rot) = (pos, rot);
			DebugUtility.AddLog("Player Teleport");
		}

		public IAspect Clone()
		{
			return new ShipAspect(_collider, _mobility, _weapon);
		}
	}
}
