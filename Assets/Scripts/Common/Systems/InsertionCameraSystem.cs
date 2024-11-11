using Asteroids.Common.Stores;
using Asteroids.Core;
using UnityEngine;


namespace Asteroids.Common.Systems
{
	internal class InsertionCameraSystem : BaseSystem<ICommonContainer>
	{
		private readonly Camera _camera;

		public InsertionCameraSystem(ICommonContainer container) : base(container)
		{
			_camera = Camera.main;
		}

		public override void OnUpdate(in float time, in float delta)
		{
			var rect = _camera.pixelRect;
			rect.min = _camera.ScreenToWorldPoint(new Vector3(rect.min.x, rect.min.y, 10f));
			rect.max = _camera.ScreenToWorldPoint(new Vector3(rect.max.x, rect.max.y, 10f));
			Container.Screen = new Core.Rect(rect.xMin, rect.yMin, rect.xMax, rect.yMax);
		}
	}
}
