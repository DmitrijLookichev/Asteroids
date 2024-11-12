using Asteroids.Core.Datas;

namespace Asteroids.Core.Aspects
{
	/// <summary>
	/// Представление для временных объектов
	/// </summary>
	public class ColliderAspect : Aspect
	{
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
