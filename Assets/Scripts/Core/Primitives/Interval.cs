using System;
using Unity.Mathematics;

namespace Asteroids.Core
{
	/// <summary>
	/// Структура содержащая два граничных значения
	/// </summary>
	[Serializable]
	public struct Interval : IEquatable<Interval>
	{
		/// <summary>
		/// Минимальноее граничное значение
		/// </summary>
		public float Min;
		/// <summary>
		/// Максимальное граничное значение
		/// </summary>
		public float Max;

		public Interval(float value) => (Min, Max) = (value, value);
		public Interval(float min, float max)
		{
			if (min > max || max < min) throw new ArgumentException("Incorrectly specified interval boundaries!");
			(Min, Max) = (min, max);
		}
		public Interval(int min, int max) : this((float)min, (float)max) { }

		/// <summary>
		/// Попадает-ли заданное число в интервал (не строгое сравнение границ)
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <returns>Входит-ли число в интервал</returns>
		/// <remarks>Для настраиваемой проверки используется ConfContains</remarks>
		public bool SoftContains(float value) => Min <= value && value <= Max;
		/// <summary>
		/// Попадает-ли заданное число в интервал (строгое сравнение границ)
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <returns>Входит-ли число в интервал</returns>
		/// <remarks>Для настраиваемой проверки используется ConfContains</remarks>
		public bool StrictContains(float value) => Min < value && value < Max;
		/// <summary>
		/// Попадает-ли заданное число в интервал
		/// </summary>
		/// <param name="value">Проверяемое число</param>
		/// <param name="excludeMin">Не строго проверять по нижней границе</param>
		/// <param name="excludeMax">Не строго проверять по верхней границе</param>
		/// <returns>Входит-ли число в интервал</returns>
		public bool ConfContains(float value, bool excludeMin, bool excludeMax)
		{
			var result1 = excludeMin
				? value > Min
				: value >= Min;

			var result2 = excludeMax
				? value < Max
				: value <= Max;

			return result1 && result2;
		}

		public float Clamp(float value)
		{
			return value > Max ? Max :
				value < Min ? Min : value;
		}

		public float Clamp(int value) => Clamp((float)value);
		public float Clamp(double value) => Clamp((float)value);

		public float Lerp(float delta) => math.lerp(Min, Max, delta);
		public float Lerp(float value, float max) => math.lerp(Min, Max, value / max);

		public bool Equals(Interval interval)
			=> math.abs(interval.Min - Min) < math.EPSILON && math.abs(interval.Max - Max) < math.EPSILON;

		public override bool Equals(object obj)
			=> obj is Interval interval && Equals(interval);
		public override string ToString()
			=> $"{Min} ::: {Max}";
		public override int GetHashCode()
			=> (Min, Max).GetHashCode();
		public static bool operator ==(Interval a, Interval b)
			=> a.Equals(b);
		public static bool operator !=(Interval a, Interval b)
			=> !a.Equals(b);
		public static implicit operator Interval((float, float) pair)
			=> new Interval(pair.Item1, pair.Item2);
	}
}