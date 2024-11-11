using Asteroids.Common.Actors;
using Asteroids.Common.Presentation;
using Asteroids.Core;

namespace Asteroids.Common.Stores
{
	internal interface ICommonContainer : ICoreContainer
	{
		IActorPool Actors { get; }
		ShipActor PlayerActor { get; }
		PresentationController Presentation { get; }
	}
}
