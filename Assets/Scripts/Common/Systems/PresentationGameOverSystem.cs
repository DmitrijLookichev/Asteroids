using Asteroids.Common.Stores;
using Asteroids.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Common.Systems
{
	/// <summary>
	/// Обработка события окончания игры
	/// </summary>
	internal class PresentationGameOverSystem : BaseSystem<ICommonContainer>, IDisposable
	{
		public PresentationGameOverSystem(ICommonContainer container) : base(container)	
		{
			Time.timeScale = 1f;
			var pause = Container.Presentation.Pause;
			pause.Panel.SetActive(false);
			pause.Restart.onClick.AddListener(OnRestart);
			pause.Quit.onClick.AddListener(OnQuit);
		}

		public override void OnUpdate(in float time, in float delta)
		{
			if(Container.Player.Input.Get(Core.Datas.ShipInput.Values.Pause))
			{
				Container.Presentation.Pause.Panel.SetActive(true);
				Time.timeScale = 0f;
				DebugUtility.AddError("Game Over!");
			}
		}

		public void Dispose()
		{
			var pause = Container.Presentation.Pause;
			pause.Restart.onClick.RemoveListener(OnRestart);
			pause.Quit.onClick.RemoveListener(OnQuit);
		}

		private void OnRestart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		private void OnQuit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
