using System.Collections.Generic;
using System.Diagnostics;

namespace Asteroids.Core
{
	/// <summary>
	/// Утилита для проброски логов из Core сборки
	/// </summary>
	public static class DebugUtility
	{
		public enum LogType : byte
		{
			Log, Warning, Error
		}

		public static Queue<(LogType Type, string Message)> Queue { get; } = new(64);

		[Conditional("UNITY_EDITOR")]
		public static void AddLog(string message)
			=> Queue.Enqueue((LogType.Log, ConcatString(message)));
		[Conditional("UNITY_EDITOR")]
		public static void AddWarning(string message)
			=> Queue.Enqueue((LogType.Warning, ConcatString(message)));
		[Conditional("UNITY_EDITOR")]
		public static void AddError(string message)
			=> Queue.Enqueue((LogType.Error, ConcatString(message)));
		
		private static string ConcatString(string message)
			=> $"<b>[Asteroids]</b>: {message}";
	}
}