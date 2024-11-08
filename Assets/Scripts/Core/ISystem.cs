namespace Asteroids.Core
{
	public interface ISystem
	{
		void OnUpdate(in float time, in float delta);
	}
}