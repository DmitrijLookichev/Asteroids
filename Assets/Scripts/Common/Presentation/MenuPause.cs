using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids.Common.Systems
{
	public class MenuPause : MonoBehaviour
	{
		[SerializeField]
		private Button _yesButton;
		[SerializeField]
		private Button _noButton;

		private void Awake()
		{
			_yesButton.onClick.AddListener(OnRestart);
			_noButton.onClick.AddListener(OnQuit);
		}

		private void OnDestroy()
		{
			_yesButton.onClick.RemoveListener(OnRestart);
			_noButton.onClick.RemoveListener(OnQuit);
		}

		private void OnRestart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		private void OnQuit()
		{
			Application.Quit();
		}
	}
}
