namespace Asteroids.Core
{
	public readonly struct Rect
	{
		public readonly float xMin;
		public readonly float yMin;
		public readonly float xMax;
		public readonly float yMax;

		public Rect(float xMin, float yMin, float xMax, float yMax)
		{
			(this.xMin, this.yMin, this.xMax, this.yMax) = (xMin, yMin, xMax, yMax);
		}
	}
}
