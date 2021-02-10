using System;
using System.Linq;
using CSharp.Chatwork.Internal;
using CSharp.Chatwork.Properties;

namespace CSharp.Chatwork
{
	public class ChatworkException : Exception
	{
		public ChatworkException(string message)
			: base(message)
		{
		}

		public ChatworkException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public ChatworkException(Exception innerException)
			: base(Resources.ExceptionBasic)
		{

		}

		public ChatworkException(string[] errors, int statusCode)
			: base(Resources.ExceptionApiError)
		{
			this.ApiErrors = errors;
			this.HttpStatusCode = statusCode;
		}

		public override string ToString()
		{
			return !this.ApiErrors.Any()
				? base.ToString()
				: this.ApiErrors.JoinToString(Environment.NewLine);
		}

		public string[] ApiErrors { get; set; }
		public int HttpStatusCode { get; set; }
	}
}
