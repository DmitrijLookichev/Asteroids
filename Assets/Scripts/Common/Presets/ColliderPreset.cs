using UnityEngine;

namespace Asteroids.Common.Presets
{
	/// <summary>
	/// настройки примитивного аспекта (прожектайлы и астеройды)
	/// </summary>
	[CreateAssetMenu(fileName = "NewColliderPreset", menuName = "Presets/Collider actor", order = 2)]
	public class ColliderPreset : ScriptableObject
	{
		[field: SerializeField, Min(0.1f)]
		public float MoveSpeed { get; private set; } = 5f;
		[field: SerializeField, Min(0.1f)]
		public float Lifetime { get; private set; } = 5f;
	}
}