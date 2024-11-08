namespace Asteroids.Core.Datas
{
	public struct ShipInput
	{
		[System.Flags]
		public enum Values : byte
		{
			None = 0 << 0,
			Acceleration = 1 << 0,
			Fire = 1 << 1,
			Laser = 1 << 2,
			// = 1 << 3,
			// = 1 << 4,
			// = 1 << 5,
			// = 1 << 6,
			Pause = 1 << 7
		}

		private Values _flag;
		//todo add in Values?
		public float Rotate;

		public void Set(Values input, bool value)
			=> _flag = value
				? _flag | input
				: _flag & ~input;
		public readonly bool Get(Values input)
			=> (_flag & input) != 0;

		public void Reset() => _flag = 0;
	}
}