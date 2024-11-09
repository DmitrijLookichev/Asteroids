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

		public static bool Temp_Check(ObjectType a, ObjectType b)
		{
			switch (a, b)
			{
				case (ObjectType.Player, ObjectType.Player):
					return false;
				case (ObjectType.Player, ObjectType.Alien):
					return true;
				case (ObjectType.Player, ObjectType.Asteroid):
					return true;
				case (ObjectType.Player, ObjectType.ProjectilePlayer):
					return false;
				case (ObjectType.Player, ObjectType.ProjectileAlien):
					return true;
				case (ObjectType.Alien, ObjectType.Player):
					return true;
				case (ObjectType.Alien, ObjectType.Alien):
					return false;
				case (ObjectType.Alien, ObjectType.Asteroid):
					return false;
				case (ObjectType.Alien, ObjectType.ProjectilePlayer):
					return true;
				case (ObjectType.Alien, ObjectType.ProjectileAlien):
					return false;
				case (ObjectType.Asteroid, ObjectType.Player):
					return true;
				case (ObjectType.Asteroid, ObjectType.Alien):
					return false;
				case (ObjectType.Asteroid, ObjectType.Asteroid):
					return false;
				case (ObjectType.Asteroid, ObjectType.ProjectilePlayer):
					return true;
				case (ObjectType.Asteroid, ObjectType.ProjectileAlien):
					return false;
				case (ObjectType.ProjectilePlayer, ObjectType.Player):
					return false;
				case (ObjectType.ProjectilePlayer, ObjectType.Alien):
					return true;
				case (ObjectType.ProjectilePlayer, ObjectType.Asteroid):
					return true;
				case (ObjectType.ProjectilePlayer, ObjectType.ProjectilePlayer):
					return false;
				case (ObjectType.ProjectilePlayer, ObjectType.ProjectileAlien):
					return false;
				case (ObjectType.ProjectileAlien, ObjectType.Player):
					return true;
				case (ObjectType.ProjectileAlien, ObjectType.Alien):
					return false;
				case (ObjectType.ProjectileAlien, ObjectType.Asteroid):
					return false;
				case (ObjectType.ProjectileAlien, ObjectType.ProjectilePlayer):
					return false;
				case (ObjectType.ProjectileAlien, ObjectType.ProjectileAlien):
					return false;
			}
			return false;
		}
	}
}