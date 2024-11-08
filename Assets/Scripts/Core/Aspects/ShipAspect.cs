using Asteroids.Core.Datas;
using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public class ShipAspect
	{
		private RigidTransform _transform;
		private float3 _velocity;
		private ShipInput _input;

		//todo properties?
		public ShipMobility Mobility;
		public byte Lifes;
		public float FireReload;
		public float LaserReload;

		public ref RigidTransform Transform { get => ref _transform; }
		public ref float3 Velocity { get => ref _velocity; }
		public ref ShipInput Input { get => ref _input; }

		public ShipAspect(ShipMobility mobility, byte lifes, float fireReload,
			float laserReload, ShipInput input)
		{
			(Transform, Mobility, Lifes, FireReload, LaserReload, Input)
				= (RigidTransform.identity, mobility, lifes, fireReload, laserReload, input);
		}

		public void Teleport(float3 pos, quaternion rot)
		{
			(_transform.pos, _transform.rot) = (pos, rot);
			DebugUtility.AddLog("Player Teleport");
		}
	}
}
