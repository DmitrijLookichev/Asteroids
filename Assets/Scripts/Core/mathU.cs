using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Asteroids.Core
{
	/// <summary>
	/// Кастомные математические функции
	/// </summary>
	public static class mathU
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClampMagnitude(float3 vector, float maxLength)
		{
			float num = math.lengthsq(vector);
			if (num > maxLength * maxLength)
			{
				float num2 = (float)math.sqrt(num);
				float num3 = vector.x / num2;
				float num4 = vector.y / num2;
				float num5 = vector.z / num2;
				return new float3(num3 * maxLength, num4 * maxLength, num5 * maxLength);
			}

			return vector;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(this float3 from, float3 to)
		{
			var num = (float)math.sqrt((double)math.lengthsq(from) * math.lengthsq(to));
			return (double)num < 1.0000000036274937E-15
				? 0.0f
				: (float)math.acos((double)math.clamp(math.dot(from, to) / num, -1f, 1f)) * 57.29578f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SignedAngle(float3 from, float3 to, float3 axis)
		{
			float num = Angle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.x - from.x * to.z;
			float num4 = from.x * to.y - from.y * to.x;
			float num5 = math.sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
			return num * num5;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximately(float a, float b)
		{	
			return math.abs(b - a) < math.max(1E-06f * math.max(math.abs(a), math.abs(b)), math.EPSILON * 8f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ProjectPointLine(float3 point, float3 lineStart, float3 lineEnd)
		{
			var rhs = point - lineStart;
			var vector = lineEnd - lineStart;
			float magnitude = math.length(vector);
			var normalize = vector / magnitude;

			float value = math.dot(normalize, rhs);
			value = math.clamp(value, 0f, magnitude);
			return lineStart + normalize * value;
		}
	}
}