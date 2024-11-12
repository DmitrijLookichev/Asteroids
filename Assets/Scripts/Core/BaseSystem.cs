namespace Asteroids.Core
{
	public abstract class BaseSystem<T> : ISystem
	{
		protected T Container { get; }

		public abstract void OnUpdate(in float time, in float delta);

		public BaseSystem(T container)
			=> Container = container;
	}

	public interface ISystem
	{
		void OnUpdate(in float time, in float delta);
	}
}
