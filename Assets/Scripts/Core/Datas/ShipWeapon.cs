using Unity.Mathematics;

namespace Asteroids.Core.Datas
{
	public readonly struct ShipWeapon
	{
		public readonly float3 WeaponOffset;
		public readonly float FireReload;
		public readonly float LaserReload;

		public ShipWeapon(float3 weaponOffset, float fireReload, float laserReload)
		{
			(WeaponOffset, FireReload, LaserReload) = (weaponOffset, fireReload, laserReload);
		}
	}
}
