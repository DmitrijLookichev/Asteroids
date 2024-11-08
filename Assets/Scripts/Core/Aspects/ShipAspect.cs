using Asteroids.Core.Datas;
using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	//todo struct in Container??
	public class ShipAspect : IAspect
	{
		private RigidTransform _transform;
		private float3 _velocity;
		private ShipInput _input;

		//todo properties?
		public ShipMobility Mobility;
		public byte Lifes;
		
		public float LaserReload;

		public uint Identity { get; set; }

		public ref RigidTransform Transform { get => ref _transform; }
		public ref float3 Velocity { get => ref _velocity; }
		public ref ShipInput Input { get => ref _input; }

		public ShipAspect(ShipMobility mobility, byte lifes,
			float laserReload, ShipInput input)
		{
			(Transform, Mobility, Lifes, LaserReload, Input)
				= (RigidTransform.identity, mobility, lifes, laserReload, input);
		}

		public void Teleport(float3 pos, quaternion rot)
		{
			(_transform.pos, _transform.rot) = (pos, rot);
			DebugUtility.AddLog("Player Teleport");
		}
	}
}
