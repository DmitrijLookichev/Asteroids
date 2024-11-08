using Asteroids.Core;
using UnityEngine;

using Collider = Asteroids.Core.Datas.Collider;

namespace Asteroids.Presentation.Objects
{
	public class VisualProvider : MonoBehaviour
	{
		[SerializeField]
		private ObjectType _type;
		[SerializeField]
		private float _radius;

		public Collider GetCollider()
		{
			return new Collider(_radius, _type);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, _radius);
		}
	}
}