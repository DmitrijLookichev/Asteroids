using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Common.Presentation
{
    public class PresentationController : MonoBehaviour
    {
		[System.Serializable]
		public struct Menu
		{
			[field: SerializeField]
			public GameObject Panel { get; private set; }
			[field: SerializeField]
			public Button Restart { get; private set; }
			[field: SerializeField]
			public Button Quit { get; private set; }
		}

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

		[field: SerializeField, Space(15f)]
		public Menu Pause { get; private set; }
	}
}
