using Asteroids.Common.Actors;
using Asteroids.Core;
using Asteroids.Core.Aspects;
using Asteroids.Core.Systems;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Asteroids.Common.Stores
{
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
			ебанет щас тут, так как я в фориче делаю ColliderLifetimeSystem
			var behaviour = _tempActors[aspect.Identity];

			_tempAspects.Remove(aspect.Identity);
			_tempActors.Remove(aspect.Identity);

			Object.Destroy(behaviour);
		}

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

	}

	
}
