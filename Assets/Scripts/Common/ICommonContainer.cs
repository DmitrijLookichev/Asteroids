using Asteroids.Common.Objects;
using Asteroids.Core;

namespace Asteroids.Common
{
	internal interface ICommonContainer : ICoreContainer
	{
		ShipBehaviour PlayerBehaviour { get; }
	}
}
