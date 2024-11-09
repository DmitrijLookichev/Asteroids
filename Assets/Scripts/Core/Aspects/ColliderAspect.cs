using Asteroids.Core.Datas;

using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public class ColliderAspect : IAspect
	{
		private CollisionData _collider;
		private RigidTransform _transform;

		public uint Identity { get; set; }

		//Components
		public ref CollisionData Collider => ref _collider;
		public ref RigidTransform Transform => ref _transform;
		public float Speed { get; }
		public float Lifetime { get; }
		public float TimeToDie { get; set; }

		

		public ColliderAspect(CollisionData collider, float speed, float lifetime)
		{
			_collider = collider;
			(Transform, Speed, Lifetime)
				= (RigidTransform.identity, speed, lifetime);
		}

		public IAspect Clone()
		{
			return new ColliderAspect(_collider, Speed, Lifetime);
		}
	}
}
