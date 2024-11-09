using Asteroids.Common.Actors;
using Asteroids.Core;

namespace Asteroids.Common.Stores
{
	internal interface ICommonContainer : ICoreContainer
	{
		ShipActor PlayerBehaviour { get; }
		ICommonPool<ColliderActor> ProjectileBehaviours { get; }
	}
}
