using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public class ColliderAspect : IAspect
	{
		private RigidTransform _transform;

		public uint Identity { get; set; }

		//Components
		public ref RigidTransform Transform { get => ref _transform; }
		public float Speed { get; }
		public float Lifetime { get; }
		public float TimeToDie { get; set; }

		public ColliderAspect(float speed, float lifetime)
		{
			(Transform, Speed, Lifetime)
				= (RigidTransform.identity, speed, lifetime);
		}

		public IAspect Clone()
		{
			return new ColliderAspect(Speed, Lifetime);
		}
	}
}
