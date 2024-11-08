using UnityEngine;

namespace Asteroids.Common.Objects
{
    public class ShipBehaviour : IdentityBehaviour
	{
        [field: SerializeField]
        public Vector3 FireOffset { get; private set; }

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();

            var transform = this.transform;
            var start = transform.position + FireOffset;
            var end = start + transform.up * .3f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(start, .05f);
            Gizmos.DrawLine(start, end);
		}
	}
}
