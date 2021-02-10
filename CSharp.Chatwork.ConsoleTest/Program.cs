using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace CSharp.Chatwork.ConsoleTest
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("APIキー：");
			var key = Console.ReadLine();
			if (key == null) return;

			var token = ChatworkToken.Create(key);

			Console.WriteLine($"あなたの情報");
			Console.WriteLine(Dump(token.Me.GetAsync().Result));

			Console.WriteLine($"あなたのステータス");
			Console.WriteLine(Dump(token.My.Status.GetAsync().Result));

			Console.WriteLine($"あなたのタスク");
			Console.WriteLine(Dump(token.My.Task.GetAsync().Result));

			Console.ReadLine();
		}

		private static string Dump(object obj)
		{
			if (obj is IEnumerable)
			{
				var sb = new StringBuilder();
				foreach (var obj2 in (IEnumerable)obj)
				{
					sb.Append("--------------------");
					sb.Append(
						string.Join(
							Environment.NewLine,
							obj2
								.GetType()
								.GetProperties()
								.Select(prop => $"{prop.Name.PadLeft(20)} : {prop.GetValue(obj)}")));
				}

				return sb.ToString();
			}

			return string.Join(
				Environment.NewLine,
				obj.GetType().GetProperties().Select(prop => $"{prop.Name.PadLeft(20)} : {prop.GetValue(obj)}"));
		}
	}
}
