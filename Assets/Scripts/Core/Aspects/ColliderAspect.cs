using Asteroids.Core.Datas;

namespace Asteroids.Core.Aspects
{
	public class ColliderAspect : Aspect
	{
		public uint Identity { get; set; }

		public float Speed { get; }
		public float Lifetime { get; }
		public float TimeToDie { get; set; }

		

		public ColliderAspect(CollisionData collider, float speed, float lifetime) : base(collider)
		{
			(Speed, Lifetime) = (speed, lifetime);
		}

		public override Aspect Clone()
		{
			return new ColliderAspect(Collider, Speed, Lifetime);
		}
	}
}
