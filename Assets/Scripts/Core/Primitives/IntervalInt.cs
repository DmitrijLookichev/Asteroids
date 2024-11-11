using System;
using Unity.Mathematics;

namespace Asteroids.Core
{
	/// <summary>
	/// Структура содержащая два граничных значения
	/// </summary>
	[Serializable]
	public struct IntervalInt : IEquatable<IntervalInt>
	{
		/// <summary>
		/// Минимальноее граничное значение
		/// </summary>
		public int Min;
		/// <summary>
		/// Максимальное граничное значение
		/// </summary>
		public int Max;

		public IntervalInt(int value) => (Min, Max) = (value, value);
		public IntervalInt(int min, int max)
		{
			if (min > max || max < min) throw new ArgumentException("Incorrectly specified interval boundaries!");
			(Min, Max) = (min, max);
		}

		/// <summary>
		/// Попадает-ли заданное число в интервал (не строгое сравнение границ)
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <returns>Входит-ли число в интервал</returns>
		/// <remarks>Для настраиваемой проверки используется ConfContains</remarks>
		public bool SoftContains(int value) => Min <= value && value <= Max;
		/// <summary>
		/// Попадает-ли заданное число в интервал (строгое сравнение границ)
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <returns>Входит-ли число в интервал</returns>
		/// <remarks>Для настраиваемой проверки используется ConfContains</remarks>
		public bool StrictContains(int value) => Min < value && value < Max;
		/// <summary>
		/// Попадает-ли заданное число в интервал
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <param name="excludeMin">Не строго проверять по нижней границе</param>
		/// <param name="excludeMax">Не строго проверять по верхней границе</param>
		/// <returns>Входит-ли число в интервал</returns>
		public bool ConfContains(int value, bool excludeMin, bool excludeMax)
		{
			var result1 = excludeMin
				? value > Min
				: value >= Min;

			var result2 = excludeMax
				? value < Max
				: value <= Max;

			return result1 && result2;
		}

		public int Clamp(int value)
		{
			return value > Max ? Max :
				value < Min ? Min : value;
		}

		public float Lerp(int delta) => math.lerp(Min, Max, delta);
		public float Lerp(int value, int max) => math.lerp(Min, Max, value / max);

		public bool Equals(IntervalInt interval)
			=> math.abs(interval.Min - Min) < math.EPSILON && math.abs(interval.Max - Max) < math.EPSILON;

		public override bool Equals(object obj)
			=> obj is IntervalInt interval && Equals(interval);
		public override string ToString()
			=> $"{Min} ::: {Max}";
		public override int GetHashCode()
			=> (Min, Max).GetHashCode();
		public static bool operator ==(IntervalInt a, IntervalInt b)
			=> a.Equals(b);
		public static bool operator !=(IntervalInt a, IntervalInt b)
			=> !a.Equals(b);
		public static implicit operator IntervalInt((int, int) pair)
			=> new IntervalInt(pair.Item1, pair.Item2);
	}
}
