using Asteroids.Core.Aspects;

using System.Collections.Generic;
namespace Asteroids.Core
{
	public interface ICorePool<TAspect> : IEnumerable<TAspect>
		where TAspect : IAspect
	{
		TAspect Temp_GetAspect();
		void Temp_ReturnAspect(TAspect aspect);
	}
}
