using Asteroids.Core.Aspects;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Создание мелких астеройдов на местах смерти крупных
	/// </summary>
	public class SmallAsteroidSpawnSystem : BaseSystem<ICoreContainer>
	{
		private Random _random;
		public SmallAsteroidSpawnSystem(ICoreContainer container) : base(container)	
		{
			_random = new Random(1995);
		}

		public override void OnUpdate(in float time, in float delta)
		{
			while(Container.Data.SmallAsteroids.Count > 0)
			{
				var pos = Container.Data.SmallAsteroids.Pop();
				var interval = Container.Data.SpawnSmallAsteroids;
				var count = _random.NextInt(interval.Min, interval.Max + 1);
				for (int i = 0; i < count; ++i)
				{
					var asteroid = Container.Aspects.GetAspect<ColliderAspect>(ObjectType.SmallAsteroid);
					asteroid.Transform.pos = pos;
					asteroid.Transform.rot = quaternion.Euler(0f, 0f, _random.NextFloat(0f, 359f));
					asteroid.TimeToDie = time + asteroid.Lifetime;
				}
			}			
		}
	}
}
