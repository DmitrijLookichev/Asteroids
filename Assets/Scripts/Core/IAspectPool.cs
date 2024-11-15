﻿using Asteroids.Core.Aspects;

using System.Collections.Generic;
namespace Asteroids.Core
{
	/// <summary>
	/// Интерфейс для работы с пулом в Core части проекта
	/// </summary>
	public interface IAspectPool
	{
		Aspect GetAspect(ObjectType type);
		T GetAspect<T>(ObjectType type) where T : Aspect;
		void ReturnAspect(Aspect aspect);
		void ConfirmChanged();

		IEnumerable<Aspect> GetEnumerable(int mask);
	}
}
