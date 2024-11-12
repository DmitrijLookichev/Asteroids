using Asteroids.Common.Actors;
using Asteroids.Core;
using Asteroids.Core.Aspects;

using System.Collections;
using System.Collections.Generic;

namespace Asteroids.Common.Stores
{
	internal partial class ObjectPool : IActorPool, IAspectPool
	{
		/// <summary>
		/// Гибкий перечислитель для работы со всеми включенными аспектами по маске <seealso cref="ObjectType"/>
		/// </summary>
		private readonly struct Enumerable : IEnumerable<Aspect>
		{
			private readonly int _mask;
			private readonly Dictionary<Aspect, Actor>[] _data;
			/// <summary>
			/// <seealso cref="PoolUtility"/>
			/// </summary>
			public Enumerable(Dictionary<Aspect, Actor>[] data, int mask)
				=> (_data, _mask) = (data, mask);

			public IEnumerator<Aspect> GetEnumerator()
				=> new AspectEnumerator(_data, _mask);

			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
		}

		/// <summary>
		/// Итератор по аспектам, заданных типов
		/// </summary>
		private struct AspectEnumerator : IEnumerator<Aspect>
		{
			private readonly int _mask;
			private readonly Dictionary<Aspect, Actor>[] _data;

			private int _index;
			private Dictionary<Aspect, Actor>.KeyCollection.Enumerator _numerator;

			public Aspect Current => _numerator.Current;


			public bool MoveNext()
			{
				while(_index == -1 || !_numerator.MoveNext())
				{
					do
					{
						++_index;
						if (_index >= _data.Length) return false;
					} while ((_mask & (1 << _index)) == 0);

					_numerator = _data[_index].Keys.GetEnumerator();
				}

				return true;
			}			

			public AspectEnumerator(Dictionary<Aspect, Actor>[] data, int mask)
				=> (_data, _mask, _index) = (data, mask, -1);
			object IEnumerator.Current => _numerator.Current;
			public void Dispose() { }
			public void Reset() => (_index, _numerator) = (-1, default);
		}
	}
}
