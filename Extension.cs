using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace regex_analyze_demo
{
	public static class Extension
	{
		public static void invokeMethod<T>(this IEnumerable<T> ienumerable, Action<T> action)
		{
			foreach (T local in ienumerable)
			{
				action(local);
			}
		}

		public static HashSet<T> toHashSet<T>(this IEnumerable<T> ienumerable)
		{
			return new HashSet<T>(ienumerable);
		}
	}
}
