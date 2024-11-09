using Asteroids.Core.Aspects;

namespace Asteroids.Core
{
	public interface ICoreContainer
	{
		ref ShipAspect PlayerAspect { get; }
		ICorePool<ColliderAspect> ProjectileAspects { get; }
	}
}
