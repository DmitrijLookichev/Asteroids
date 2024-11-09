using Asteroids.Common.Actors;
using Asteroids.Core;
using Asteroids.Core.Aspects;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Asteroids.Common.Stores
{
	//todo можно сделать кастомный енумератор, который будет учитывать "удаленные" объекты
	//и который будет в конце цикла удалять их
	internal class ObjectPool<TActor, TAspect> 
		: ICommonPool<TActor>, ICorePool<TAspect>
		where TActor : ColliderActor where TAspect : IAspect
	{
		private static uint _identity = 0u;

		//private readonly List<TAspect> _aspects;
		private readonly TAspect _prefabAspect;
		private readonly TActor _prefabActor;

		private readonly Dictionary<uint, TAspect> _tempAspects;
		private readonly Dictionary<uint, TActor> _tempActors;

		#region ICommonPool API
		public TActor Temp_GetActor(uint identity)
		{
			//todo check miss (mb public bool TryGetActor(uint identity, out TActor actor)?)
			return _tempActors[identity];
		}
		#endregion

		#region ICorePool API
		public TAspect Temp_GetAspect()
		{
			var aspect = (TAspect)_prefabAspect.Clone();
			var behaviour = Object.Instantiate(_prefabActor);

			var id = ++_identity;
			aspect.Identity = id;
			behaviour.Identity = id;
			_tempAspects.Add(id, aspect);
			_tempActors.Add(id, behaviour);

			return aspect;
		}

		public void Temp_ReturnAspect(TAspect aspect)
		{
			_tempReturned.Push(aspect.Identity);
		}

		private Stack<uint> _tempReturned = new (32);

		public void Temp_ClearReturnedAspects()
		{
			while(_tempReturned.Count > 0)
			{
				var identity = _tempReturned.Pop();

				var behaviour = _tempActors[identity];
				Object.Destroy(behaviour.gameObject);

				_tempAspects.Remove(identity);
				_tempActors.Remove(identity);
			}			
		}
#endregion

		public ObjectPool(TActor prefabB, TAspect prefabA, int capacity)
		{
			(_prefabAspect, _prefabActor) = (prefabA, prefabB);
			(_tempAspects, _tempActors) = (new(capacity), new(capacity));
			//todo
			//_aspects = new List<TAspect>(capacity);
			//todo init 
		}

		public IEnumerator<TAspect> GetEnumerator()
			=> _tempAspects.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
	}

	internal interface ICommonPool<TActor>
		where TActor : MonoBehaviour
	{
		TActor Temp_GetActor(uint identity);
	}

	
}
