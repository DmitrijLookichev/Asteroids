using Asteroids.Common.Stores;
using Asteroids.Core;
using UnityEngine;


namespace Asteroids.Common.Systems
{
	/// <summary>
	/// Вводит в Core рамки экрана для расчета телепорта скрывшихся из виду объектов
	/// </summary>
	internal class InsertionCameraSystem : BaseSystem<ICommonContainer>
	{
		//отступ для спауна вне видимости экрана
		private const float c_offset = 1.08f;

		private readonly Camera _camera;

		public InsertionCameraSystem(ICommonContainer container) : base(container)
		{
			_camera = Camera.main;
		}

		public override void OnUpdate(in float time, in float delta)
		{
			var rect = _camera.pixelRect;
			var min = _camera.ScreenToWorldPoint(new Vector3(rect.min.x, rect.min.y, 10f));
			var max = _camera.ScreenToWorldPoint(new Vector3(rect.max.x, rect.max.y, 10f));

			//visual upgrade
			//расширяет границу рамки экрана, чтобы телепорт срабатывал с запасом по расстоянию
			min *= c_offset;
			max *= c_offset;			
			Container.Screen = new Core.Rect(min.x, min.y, max.x, max.y);
		}
	}
}
