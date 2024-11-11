using Unity.Mathematics;

namespace Asteroids.Core.Datas
{
	public readonly struct ShipWeapon
	{
		public readonly float3 WeaponOffset;
		public readonly float FireReload;

		public ShipWeapon(float3 weaponOffset, float fireReload)
		{
			(WeaponOffset, FireReload) = (weaponOffset, fireReload);
		}
	}
}
