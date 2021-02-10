using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Chatwork.Internal
{
	internal class ApiParameter : IReadOnlyList<KeyValuePair<string, object>>
	{
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return this.InternalList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Count => this.InternalList.Count;
		public KeyValuePair<string, object> this[int index] => this.InternalList[index];

		public string ToQuery()
		{
			return this.Where(kvp => !string.IsNullOrEmpty(ConvertValue(kvp.Value))).Select(kvp => $"{kvp.Key.ToLowerSnakeCase()}={UrlEncode(ConvertValue(kvp.Value))}").JoinToString("&");
		}

		public void Add(string key, object obj)
		{
			this.InternalList.Add(new KeyValuePair<string, object>(key, obj));
		}

		private string ConvertValue(object obj)
		{
			switch (obj)
			{
				case null:
					return string.Empty;

				case string s:
					return s;

				case int _:
					return obj.ToString();

				case long _:
					return obj.ToString();

				case bool b:
					return b ? "1" : "0";

				case Enum _:
					return StringUtil.ToEmpty(obj);

				default:
					throw new NotSupportedException();
			}
		}

		private static string UrlEncode(string source)
		{
			const string USABLE_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
			return Encoding.UTF8.GetBytes(source).Select(x => x < 0x80 && USABLE_CHARS.Contains(((char)x).ToString()) ? ((char)x).ToString() : '%' + x.ToString("X2")).JoinToString();
		}

		private List<KeyValuePair<string, object>> InternalList { get; } = new List<KeyValuePair<string, object>>();
	}
}
