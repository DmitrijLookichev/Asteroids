using System;
using Unity.Mathematics;

namespace Asteroids.Core
{
	/// <summary>
	/// ��������� ���������� ��� ��������� ��������
	/// </summary>
	[Serializable]
	public struct Interval : IEquatable<Interval>
	{
		/// <summary>
		/// ������������ ��������� ��������
		/// </summary>
		public float Min;
		/// <summary>
		/// ������������ ��������� ��������
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
		/// ��������-�� �������� ����� � �������� (�� ������� ��������� ������)
		/// </summary>
		/// <param name="value">����������� �����</param>
		/// <returns>������-�� ����� � ��������</returns>
		/// <remarks>��� ������������� �������� ������������ ConfContains</remarks>
		public bool SoftContains(float value) => Min <= value && value <= Max;
		/// <summary>
		/// ��������-�� �������� ����� � �������� (������� ��������� ������)
		/// </summary>
		/// <param name="value">����������� �����</param>
		/// <returns>������-�� ����� � ��������</returns>
		/// <remarks>��� ������������� �������� ������������ ConfContains</remarks>
		public bool StrictContains(float value) => Min < value && value < Max;
		/// <summary>
		/// ��������-�� �������� ����� � ��������
		/// </summary>
		/// <param name="value">����������� �����</param>
		/// <param name="excludeMin">�� ������ ��������� �� ������ �������</param>
		/// <param name="excludeMax">�� ������ ��������� �� ������� �������</param>
		/// <returns>������-�� ����� � ��������</returns>
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