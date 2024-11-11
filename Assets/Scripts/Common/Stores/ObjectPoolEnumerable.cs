using Asteroids.Common.Actors;
using Asteroids.Core;
using Asteroids.Core.Aspects;

using System.Collections;
using System.Collections.Generic;

namespace Asteroids.Common.Stores
{
	internal partial class ObjectPool : IActorPool, IAspectPool
	{
		private readonly struct Enumerable : IEnumerable<Aspect>
		{
			private readonly int _mask;
			private readonly Dictionary<Aspect, Actor>[] _data;
			public Enumerable(Dictionary<Aspect, Actor>[] data, int mask)
				=> (_data, _mask) = (data, mask);

			public IEnumerator<Aspect> GetEnumerator()
				=> new AspectEnumerator(_data, _mask);

			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
		}

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
					} while ((_mask & (1 << _index)) != 1);

					_numerator = _data[_index].Keys.GetEnumerator();
				}

				return true;
			}
			

			public AspectEnumerator(Dictionary<Aspect, Actor>[] data, int mask)
			{
				(_data, _mask) = (data, mask);
				_index = -1;
			}

			object IEnumerator.Current => _numerator.Current;
			public void Dispose() { }
			public void Reset()
			{
				_index = -1; _numerator = default;
			}
		}
	}
}
