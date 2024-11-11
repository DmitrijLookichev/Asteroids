using Asteroids.Core.Aspects;

namespace Asteroids.Core
{
	public interface ICoreContainer
	{
		IAspectPool Aspects { get; }
		PlayerShipAspect Player { get; }
		ref GameData Data { get; }
		ref Rect Screen { get; }
	}
}
