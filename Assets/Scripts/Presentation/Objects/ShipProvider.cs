using UnityEngine;

namespace Asteroids.Presentation.Objects
{
    public class ShipProvider : MonoBehaviour, IProvider
	{
        [SerializeField]
        private Transform _firePoint;

		private void OnDrawGizmos()
		{
            if (_firePoint == null) return;
            Gizmos.color = Color.yellow;
            var start = _firePoint.position;
            var end = start + _firePoint.forward * .3f;
            Gizmos.DrawSphere(start, .2f);
            Gizmos.DrawLine(start, end);
		}
	}
}
