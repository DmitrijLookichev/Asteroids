using UnityEngine;

namespace Asteroids.Common.Presets
{
	[CreateAssetMenu(fileName = "NewPlayerShipActorPreset", menuName = "Presets/Player Ship Actor", order = 2)]
	public class PlayerShipActorPreset : ShipActorPreset
	{
		[field: SerializeField, Min(0.1f)]
		public float LaserReload { get; private set; } = 1f;
		[field: SerializeField, Min(1f)]
		public int LaserCharges { get; private set; } = 1;
		[field: SerializeField, Min(0.1f)]
		public float VisualDuration { get; private set; } = 2f;
	}
}
