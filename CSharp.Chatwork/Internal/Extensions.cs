using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CSharp.Chatwork.Internal
{
	internal static class EnumerableExtensions
	{
		public static string JoinToString<T>(this IEnumerable<T> source, string separator = null)
		{
			return source == null
				? throw new ArgumentNullException(nameof(source))
				: separator != null
					? string.Join(separator, source)
					: string.Concat(source);
		}
	}

	internal static class StringExtensions
	{
		public static string ToLowerSnakeCase(this string source)
		{
			var sb = new StringBuilder();
			foreach (var c in source)
			{
				if ('A' <= c && c <= 'Z' && sb.Length > 0)
				{
					sb.Append("_").Append(c.ToString().ToLowerInvariant());
				}
				else
				{
					sb.Append(c.ToString());
				}
			}

			return sb.ToString();
		}
	}

	internal static class EnumExtensions
	{
		public static bool IsSuccessStatusCode(this HttpStatusCode status)
		{
			var code = (int)status;
			return 200 <= code && code <= 299;
		}
	}


}
