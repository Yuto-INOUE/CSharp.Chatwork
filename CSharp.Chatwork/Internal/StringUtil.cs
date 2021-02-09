namespace CSharp.Chatwork.Internal
{
	internal static class StringUtil
	{
		public static string ToEmpty(object obj)
		{
			return obj != null ? obj.ToString() : string.Empty;
		}
	}
}
