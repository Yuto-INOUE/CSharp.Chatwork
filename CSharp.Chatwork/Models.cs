using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Chatwork
{
	public interface IResponse
	{
		int RateLimit { get; set; }
		int RateLimitRemaining { get; set; }
		DateTime RateLimitReset { get; set; }
	}

	public abstract class Response : IResponse
	{
		public int RateLimit { get; set; }
		public int RateLimitRemaining { get; set; }
		public DateTime RateLimitReset { get; set; }
	}

	public class ListedResponse<T> : IResponse, IReadOnlyList<T>
	{
		public ListedResponse(List<T> collection)
		{
			this.InnerList = collection;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private List<T> InnerList { get; set; }
		public int RateLimit { get; set; }
		public int RateLimitRemaining { get; set; }
		public DateTime RateLimitReset { get; set; }

		public int Count { get; }
		public T this[int index] => this.InnerList[index];
	}
}
