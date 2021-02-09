using System;
using CSharp.Chatwork.Internal;

namespace CSharp.Chatwork
{
	public class ChatworkException : Exception
	{
		public ChatworkException(string[] errors, int statusCode)
		{
			this.ApiErrors = errors;
			this.HttpStatusCode = statusCode;
		}

		public override string ToString()
		{
			return this.ApiErrors.JoinToString(Environment.NewLine);
		}

		public string[] ApiErrors { get; set; }
		public int HttpStatusCode { get; set; }
	}
}
