using UnityEngine;

namespace Asteroids.Common.Actors
{
	public class ShipActor : Actor
	{
		private LineRenderer _lineRenderer;

		[field: SerializeField]
		public Vector3 FireOffset { get; private set; }

		public LineRenderer LineRenderer
		{
			get
			{
				if (_lineRenderer == null)
					_lineRenderer = GetComponent<LineRenderer>();
				return _lineRenderer;
			}
		}

		//todo remove this
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
