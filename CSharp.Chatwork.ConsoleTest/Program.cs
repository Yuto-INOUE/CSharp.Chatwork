using System;
using System.Collections;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;
using Microsoft.CodeAnalysis.Scripting.Hosting;

// ReSharper disable LocalizableElement

namespace CSharp.Chatwork.ConsoleTest
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Please enter your chatwork api key: ");
			var key = Console.ReadLine();
			if (key == null) return;

			var token = ChatworkToken.Create(key);

			try
			{
				Console.WriteLine($"Your account information");
				Console.WriteLine(Dump(token.Me.GetAsync().Result));

				Console.WriteLine($"Your status");
				Console.WriteLine(Dump(token.My.Status.GetAsync().Result));

				Console.WriteLine($"Your tasks");
				Console.WriteLine(Dump(token.My.Task.GetAsync().Result));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			Console.ReadLine();
		}

		private static string Dump(object obj)
		{
			string F(object o) => CSharpObjectFormatter.Instance.FormatObject(
				o,
				new PrintOptions
				{
					MemberDisplayFormat = MemberDisplayFormat.SeparateLines,
					MaximumOutputLength = int.MaxValue
				});

			if (obj is IEnumerable)
			{
				var sb = new StringBuilder();
				foreach (var obj2 in (IEnumerable) obj)
				{
					sb.AppendLine("-----------------------------------").AppendLine(F(obj2));
				}

				return sb.ToString();
			}

			return F(obj);
		}
	}
}
