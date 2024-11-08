namespace Asteroids.Core.Datas
{
	public readonly struct ShipMobility
	{
		//In radians
		public readonly float RotationSpeed;
		public readonly float Acceleration;
		public readonly float Deceleration;
		public readonly float MaxVelocity;

		public ShipMobility(float rotationSpeed, float acceleration,
			float deceleration, float maxVelocity)
		{
			(RotationSpeed, Acceleration, Deceleration, MaxVelocity)
				= (rotationSpeed, acceleration, deceleration, maxVelocity);
		}
	}
}