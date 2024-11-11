using Asteroids.Core.Datas;
using System;
using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public abstract class Aspect : IEquatable<Aspect>
	{
		private CollisionData _collider;
		private RigidTransform _transform;

		public int InstanceID { get; set; }

		public ref CollisionData Collider => ref _collider;
		public ref RigidTransform Transform { get => ref _transform; }

		public ObjectType Type => _collider.Type;

		public Aspect(CollisionData collisionData)
		{
			_collider = collisionData;
			_transform = RigidTransform.identity;
		}

		public abstract Aspect Clone();

		public override int GetHashCode()
			=> InstanceID;
		public override bool Equals(object obj)
			=>	obj is Aspect aspect && Equals(aspect);
		public bool Equals(Aspect other)
			=> InstanceID == other.InstanceID;
		public override string ToString()
			=> $"{GetType().Name}.{Type} = {InstanceID}";
	}
}
