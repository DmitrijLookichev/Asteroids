namespace Asteroids.Core.Datas
{
	public readonly struct ShipLaser
	{
		public readonly float LaserReload;
		public readonly int MaxCharges;
		//todo move in EngineCode?
		public readonly float VisualDuration;

		public ShipLaser(float laserReload, int maxCharges, float duration)
		{
			(LaserReload, MaxCharges, VisualDuration) 
				= (laserReload, maxCharges, duration);
		}
	}
}
