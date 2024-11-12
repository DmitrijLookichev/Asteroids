using Unity.Mathematics;

namespace Asteroids.Core
{
	public readonly struct Rect
	{
		public readonly float2 Min;
		public readonly float2 Max;

		public Rect(float xMin, float yMin, float xMax, float yMax)
		{
			(Min, Max) = (new float2(xMin, yMin), new float2(xMax, yMax));
		}
		public Rect(float2 min, float2 max)
		{
			(Min, Max) = (min, max);
		}
	}
}
