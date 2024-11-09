using Asteroids.Core.Datas;

using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public interface IAspect : IIdentity
	{
		ref CollisionData Collider { get; }

		ref RigidTransform Transform { get; }

		IAspect Clone();
	}
}
