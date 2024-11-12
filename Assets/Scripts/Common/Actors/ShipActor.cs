using UnityEngine;

namespace Asteroids.Common.Actors
{
	public class ShipActor : Actor
	{
		private LineRenderer _lineRenderer;

		[field: SerializeField]
		public Vector3 FireOffset { get; private set; }

		public LineRenderer? LineRenderer
		{
			get
			{
				if (_lineRenderer == null)
					_lineRenderer = GetComponent<LineRenderer>();
				return _lineRenderer;
			}
		}
	}
}
