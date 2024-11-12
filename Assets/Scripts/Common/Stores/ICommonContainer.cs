using Asteroids.Common.Actors;
using Asteroids.Common.Presentation;
using Asteroids.Core;

namespace Asteroids.Common.Stores
{
	/// <summary>
	/// Интерфейс контейнера для систем общего назначения
	/// </summary>
	internal interface ICommonContainer : ICoreContainer
	{
		IActorPool Actors { get; }
		ShipActor PlayerActor { get; }
		PresentationController Presentation { get; }
	}
}
