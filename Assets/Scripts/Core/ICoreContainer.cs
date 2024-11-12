using Asteroids.Core.Aspects;

namespace Asteroids.Core
{
	/// <summary>
	/// Интерфейс для работы с контейнером в Core части проекта
	/// </summary>
	public interface ICoreContainer
	{
		IAspectPool Aspects { get; }
		PlayerShipAspect Player { get; }
		ref GameData Data { get; }
		ref Rect Screen { get; }
	}
}
