using Asteroids.Common.Actors;
using Asteroids.Core;
using Asteroids.Core.Aspects;
using System.Collections.Generic;

using UnityEngine;

namespace Asteroids.Common.Stores
{
	/// <summary>
	/// Пул аспектов и связанных с ними актеров (для Common Assembly)
	/// </summary>
	internal partial class ObjectPool : IActorPool, IAspectPool
	{
		#region Internal structs
		private readonly struct PrefabData
		{
			public readonly Actor Actor;
			public readonly Aspect Aspect;
			public readonly Transform Root;

			public PrefabData(Actor actor, Aspect aspect, Transform root)
			{
				(Actor, Aspect) = (actor, aspect);
				Root = root;
			}
		}
		#endregion
		//Исходные префабы для аспектов и актеров
		private readonly Dictionary<ObjectType, PrefabData> _prefabs;
		//активированные в игре объекты
		//индекс - ObjectType аспекта
		//ключ - InstanceID аспекта (равен Actor.InstanceID) 
		private readonly Dictionary<Aspect, Actor>[] _enables;
		//выключенные аспекты и объекты
		private readonly Dictionary<Aspect, Actor>[] _disables;
		//буффер для хранения трансфера сущностей между _enables & _disables
		//необходимо для корректной работы в рамках foreach
		private readonly Dictionary<Aspect, Actor> _buffer;

		public void AddPrefab(ObjectType type, Actor actorPrefab, Aspect aspectPrefab, int capacity)
		{
			if (_prefabs.ContainsKey(type))
			{
				DebugUtility.AddError($"Try add duplicate {nameof(ObjectType)}.{type}");
				return;
			}

			//Transform root
			var root = new GameObject(actorPrefab.Type.ToString() + "Root").transform;
			root.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			root.localScale = Vector3.one;

			var data = new PrefabData(actorPrefab, aspectPrefab, root);
			_prefabs.Add(type, data);

			_enables[(int)type] = new Dictionary<Aspect, Actor>(capacity);
			var dictionary = new Dictionary<Aspect, Actor>(capacity);
			_disables[(int)type] = dictionary;			
			for (int i = 0; i < capacity; i++)
			{
				Spawn(in data, out var actor, out var aspect);
				actor.gameObject.SetActive(false);
				dictionary.Add(aspect, actor);
			}
		}

		#region ICommonPool API
		public Actor GetActor(Aspect aspect)
		{
			return _enables[(int)aspect.Collider.Type][aspect];
		}
		#endregion

		#region ICorePool API
		public Aspect GetAspect(ObjectType type)
		{
			var actor = default(Actor);
			var aspect = default(Aspect);
			foreach (var pair in _disables[(int)type])
			{
				if (_buffer.ContainsKey(pair.Key)) continue;
				(aspect, actor) = pair;
				actor.gameObject.SetActive(true);
				break;
			}
			if(aspect == null)
				Spawn(_prefabs[type], out actor, out aspect);

			_buffer.Add(aspect, actor);
			return aspect;
		}
		public T GetAspect<T>(ObjectType type)
			where T : Aspect
			=> GetAspect(type) as T;

		//Возвращает аспект в буффер переед выключением
		public void ReturnAspect(Aspect aspect)
		{
			var actor = _enables[(int)aspect.Type][aspect];
			actor.gameObject.SetActive(false);

			_buffer.Add(aspect, actor);
			DebugUtility.AddLog($"<b>[Return Aspect]</b>: {aspect}");
		}

		//Подтверждает перемещение аспектов в буффере
		public void ConfirmChanged()
		{
			//3 state
			foreach(var pair in _buffer)
			{
				var type = (int)pair.Key.Type;
				//1. Reuse (move: _disables -> _enables)
				if (_disables[type].Remove(pair.Key))
				{
					_enables[type].Add(pair.Key, pair.Value);
				}
				//2. Returned (move: _enables -> _disables)
				else if (_enables[type].Remove(pair.Key))
				{
					_disables[type].Add(pair.Key, pair.Value);
				}
				//3. New (add:  _enables)
				else
				{
					_enables[type].Add(pair.Key, pair.Value);
				}
				//todo 4. can Create and Return in one frame? (error...)
			}

			_buffer.Clear();
		}

		/// <summary>
		/// Возвращает итератор по всем аспектам
		/// </summary>
		/// <param name="mask">Маска итератора <seealso cref="PoolUtility"/></param>
		public IEnumerable<Aspect> GetEnumerable(int mask)
			=> new Enumerable(_enables, mask);
		#endregion

		public ObjectPool()
		{
			var size = System.Enum.GetValues(typeof(ObjectType)).Length;
			_prefabs = new Dictionary<ObjectType, PrefabData>(size);
			_enables = new Dictionary<Aspect, Actor>[size];
			_disables = new Dictionary<Aspect, Actor>[size];
			_buffer = new Dictionary<Aspect, Actor>(8);//todo magic number?
		}

		private void Spawn(in PrefabData data, out Actor actor, out Aspect aspect)
		{
			actor = Object.Instantiate(data.Actor, data.Root);
			aspect = data.Aspect.Clone();
			aspect.InstanceID = actor.GetHashCode();
		}
	}

	internal interface IActorPool
	{
		Actor GetActor(Aspect aspect);
	}	
}
