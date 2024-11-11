using Asteroids.Core.Aspects;

namespace Asteroids.Core
{
	public interface ICoreContainer
	{
		IAspectPool Aspects { get; }
		ShipAspect Player { get; }
		ref GameData Data { get; }
		ref Rect Screen { get; }
	}
}
