using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Asteroids.Core
{
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