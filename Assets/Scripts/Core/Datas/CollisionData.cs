namespace Asteroids.Core.Datas
{
	public readonly struct CollisionData
	{
		public readonly float Radius;
		public readonly ObjectType Type;

		public CollisionData(float radius, ObjectType type)
			=> (Radius, Type) = (radius, type);
	}
}
