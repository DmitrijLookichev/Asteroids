using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Common.Actors
{
    public class Actor : MonoBehaviour
	{
		[field: SerializeField]
		public ObjectType Type { get; private set; }
		[field: SerializeField]
		public float Radius { get; private set; }

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, Radius);
		}
	}
}
