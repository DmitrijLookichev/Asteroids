using UnityEngine;

namespace Asteroids.Common.Presets
{
	[CreateAssetMenu(fileName = "NewColliderPreset", menuName = "Presets/Collider", order = 1)]
	public class ColliderPreset : ScriptableObject
	{
		[field: SerializeField, Min(0.1f)]
		public float MoveSpeed { get; private set; } = 5f;
		[field: SerializeField, Min(0.1f)]
		public float Lifetime { get; private set; } = 5f;
	}
}