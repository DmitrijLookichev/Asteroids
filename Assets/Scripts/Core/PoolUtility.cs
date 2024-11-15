﻿using Asteroids.Core.Aspects;

using System.Collections.Generic;

namespace Asteroids.Core
{
	/// <summary>
	/// Утилита для итерационного доступа к аспектам по типу
	/// </summary>
	public static class PoolUtility
	{
		private const int _player = 1 << (int)ObjectType.Player;
		private const int _alien = 1 << (int) ObjectType.Alien;
		private const int _bigAsteroid = 1 << (int)ObjectType.BigAsteroid;
		private const int _smallAsteroid = 1 << (int)ObjectType.SmallAsteroid;
		private const int _projectilePlayer = 1 << (int)ObjectType.ProjectilePlayer;
		private const int _projectileAlien = 1 << (int)ObjectType.ProjectileAlien;

		private const int _ships = _player | _alien;
		private const int _asteroids = _bigAsteroid | _smallAsteroid;
		private const int _projectiles = _projectilePlayer | _projectileAlien;
		private const int _noShips = _asteroids | _projectiles;
		private const int _all = _ships | _noShips;

		/// <summary>
		/// Итерация по всем активным кораблям пришельцев
		/// </summary>
		public static IEnumerable<Aspect> Aliens(this IAspectPool pool)
			=> pool.GetEnumerable(_alien);
		/// <summary>
		/// Итерация по всем активным большим астеройдам
		/// </summary>
		public static IEnumerable<Aspect> BigAsteroids(this IAspectPool pool)
			=> pool.GetEnumerable(_bigAsteroid);
		/// <summary>
		/// Итерация по всем активным малым астеройдам
		/// </summary>
		public static IEnumerable<Aspect> SmallAsteroids(this IAspectPool pool)
			=> pool.GetEnumerable(_smallAsteroid);
		/// <summary>
		/// Итерация по всем активным снарядам игрока
		/// </summary>
		public static IEnumerable<Aspect> PlayerProjectiles(this IAspectPool pool)
			=> pool.GetEnumerable(_projectilePlayer);
		/// <summary>
		/// Итерация по всем активным снарядам пришельцев
		/// </summary>
		public static IEnumerable<Aspect> AlienProjectiles(this IAspectPool pool)
			=> pool.GetEnumerable(_projectileAlien);

		//Combine
		/// <summary>
		/// Итерация по всем активным кораблям (вкл. игрока)
		/// </summary>
		public static IEnumerable<Aspect> Ships(this IAspectPool pool)
			=> pool.GetEnumerable(_player | _alien);
		/// <summary>
		/// Итерация по всем активным большим и малым астеройдам
		/// </summary>
		public static IEnumerable<Aspect> Asteroids(this IAspectPool pool)
			=> pool.GetEnumerable(_bigAsteroid | _smallAsteroid);
		/// <summary>
		/// Итерация по всем активным снарядам (вкл. игрока)
		/// </summary>
		public static IEnumerable<Aspect> Projectiles(this IAspectPool pool)
			=> pool.GetEnumerable(_projectilePlayer | _projectileAlien);
		/// <summary>
		/// Итерация по всем активным снарядам и астеройдам
		/// </summary>
		public static IEnumerable<Aspect> WithoutShips(this IAspectPool pool)
			=> pool.GetEnumerable(_noShips);
		/// <summary>
		/// Итерация по всем активным аспектам в мире
		/// </summary>
		public static IEnumerable<Aspect> All(this IAspectPool pool)
			=> pool.GetEnumerable(_all);
	}
}
