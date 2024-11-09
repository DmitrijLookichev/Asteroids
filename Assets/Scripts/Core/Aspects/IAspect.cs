using Unity.Mathematics;

namespace Asteroids.Core.Aspects
{
	public interface IAspect : IIdentity
	{
		ref RigidTransform Transform { get; }
		IAspect Clone();
	}
}
