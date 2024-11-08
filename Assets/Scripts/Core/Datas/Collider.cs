namespace Asteroids.Core.Datas
{
	public readonly struct Collider
	{
		public readonly float Radius;
		public readonly ObjectType Type;

		public Collider(float radius, ObjectType type)
			=> (Radius, Type) = (radius, type);
	}
}
