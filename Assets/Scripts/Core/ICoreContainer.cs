using Asteroids.Core.Aspects;

namespace Asteroids.Core
{
	public interface ICoreContainer
	{
		ref ShipAspect PlayerAspect { get; }
	}
}
