using UnityEngine;

namespace Asteroids.Common.Presets
{
	[CreateAssetMenu(fileName = "NewShipActorPreset", menuName = "Presets/Ship Actor", order = 1)]
	public class ShipActorPreset : ScriptableObject
	{
		[field: SerializeField, Min(0.1f)]
		public float RotationSpeed { get; private set; } = 5f;
		[field: SerializeField, Min(0.1f)]
		public float Acceleration { get; private set; } = 2.5f;
		[field: SerializeField, Min(0.1f)]
		public float Deceleration { get; private set; } = .5f;
		[field: SerializeField, Min(.1f)]
		public float MaxVelocity { get; private set; } = 1f;
		[field: SerializeField, Min(0.1f)]
		public float FireReload { get; private set; } = 1f;
	}
}
