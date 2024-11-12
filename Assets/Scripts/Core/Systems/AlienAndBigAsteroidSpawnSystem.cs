using Asteroids.Core.Aspects;
using Unity.Mathematics;

namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Система создания новых астеройдов и пришельцев
	/// </summary>
	public class AlienAndBigAsteroidSpawnSystem : BaseSystem<ICoreContainer>
	{
		private Random _random;
		public AlienAndBigAsteroidSpawnSystem(ICoreContainer container) : base(container)
		{
			_random = new Random(1995);
		}

		public override void OnUpdate(in float time, in float delta)
		{
			ref var data = ref Container.Data;
			if(data.AsteroidSpawnTime < time)
			{
				var aspect = Container.Aspects.GetAspect<ColliderAspect>(ObjectType.BigAsteroid);
				aspect.TimeToDie = time + aspect.Lifetime;
				CalcTransform(ref aspect.Transform.rot, ref aspect.Transform.pos);

				data.AsteroidSpawnTime = time + _random.NextFloat(
					data.AsteroidSpawnInterval.Min, data.AsteroidSpawnInterval.Max);
			}
			if (data.AlienSpawnTime < time)
			{
				var aspect = Container.Aspects.GetAspect<ShipAspect>(ObjectType.Alien);
				CalcTransform(ref aspect.Transform.rot, ref aspect.Transform.pos);

				data.AlienSpawnTime = time + _random.NextFloat(
					data.AlienSpawnInterval.Min, data.AlienSpawnInterval.Max);
				//hardcode for persistant shooting
				aspect.Input.Set(Datas.ShipInput.Values.Fire, true);
				aspect.Input.Set(Datas.ShipInput.Values.Acceleration, true);
			}
		}

		private void CalcTransform(ref quaternion rot, ref float3 pos)
		{
			ref var rect = ref Container.Screen;
			var a = default(float3);
			var b = default(float3);
			switch(_random.NextInt(0, 4))
			{
				//Left screen border
				case 0:
					(a.x, a.y) = (rect.Min.x, rect.Min.y);
					(b.x, b.y) = (rect.Min.x, rect.Max.y);
					break;
				//Top screen border
				case 1:
					(a.x, a.y) = (rect.Min.x, rect.Max.y);
					(b.x, b.y) = (rect.Max.x, rect.Max.y);
					break;
				//Right screen border
				case 2:
					(a.x, a.y) = (rect.Max.x, rect.Max.y);
					(b.x, b.y) = (rect.Max.x, rect.Min.y);
					break;
				//Down screen border
				case 3:
					(a.x, a.y) = (rect.Max.x, rect.Min.y);
					(b.x, b.y) = (rect.Min.x, rect.Min.y);
					break;
			}

			rot = quaternion.Euler(0f, 0f, _random.NextFloat(0f, 359f));
			pos = _random.NextFloat3(a, b);
		}
	}
}
