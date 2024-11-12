
namespace Asteroids.Core.Systems
{
	/// <summary>
	/// Восстановление зарядов лазера игрока
	/// </summary>
	public class PlayerLaserRenewalSystem : BaseSystem<ICoreContainer>
	{
		public PlayerLaserRenewalSystem(ICoreContainer container) : base(container)	{}

		public override void OnUpdate(in float time, in float delta)
		{
			var player = Container.Player;
			ref var laser = ref player.Laser;

			//1. Достаточно зарядов - таймер не нужен
			if (player.LaserCharges >= laser.MaxCharges)
			{
				player.LaserReload = null;
			}
			//2. Недостаточно зарядов - таймер нужен (потратились в прошлых кадр, надо стартоваться)
			else if (player.LaserReload is null)
			{
				player.LaserReload = time + laser.LaserReload;
			}
			//3. Недостаточно зарядов - таймер не нужен (уже в процессе)
			else if (player.LaserReload <= time)
			{
				++player.LaserCharges;
				player.LaserReload = null;
			}
		}
	}
}
