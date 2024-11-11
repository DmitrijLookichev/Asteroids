using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Common.Presentation
{
    public class PresentationController : MonoBehaviour
    {
		[field: SerializeField]
		public TextMeshProUGUI Coordinates { get; private set; }
		[field: SerializeField]
		public TextMeshProUGUI Angle { get; private set; }
		[field: SerializeField]
        public TextMeshProUGUI Speed { get; private set; }
		[field: SerializeField]
		public TextMeshProUGUI LaserCount { get; private set; }
		[field: SerializeField]
		public Image LaserFill { get; private set; }
		[field: SerializeField]
		public TextMeshProUGUI LaserReload { get; private set; }
		[field: SerializeField]
		public TextMeshProUGUI Score { get; private set; }
	}
}
