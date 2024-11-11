namespace Asteroids.Core
{
	public enum ObjectType : byte
	{
		Player = 0,				//1
		Alien = 1,				//2
		BigAsteroid = 2,		//4
		SmallAsteroid = 3,		//8
		ProjectilePlayer = 4,	//16
		ProjectileAlien = 5		//32
	}
}
