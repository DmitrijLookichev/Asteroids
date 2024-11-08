using Asteroids.Core;
using Asteroids.Core.Datas;

using UnityEngine;

namespace Asteroids.Common.Objects
{
	public class IdentityBehaviour : MonoBehaviour, IIdentity
	{
		public uint Identity { get; set; }

		[SerializeField]
		private ObjectType _type;
		[SerializeField]
		private float _radius;

		public CollisionData GetCollider()
		{
			return new CollisionData(_radius, _type);
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, _radius);
		}
	}
}
