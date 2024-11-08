namespace Asteroids.Core
{
	public interface IIdentity
	{
		public const uint Empty = 0u;

		uint Identity { get; set; }

		bool Compare(IIdentity other)
		{
			if (Identity == Empty || other.Identity == Empty) 
				return false;

			return Identity == other.Identity;
		}
	}
}
