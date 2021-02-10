using System;
using Newtonsoft.Json;

namespace CSharp.Chatwork.Internal
{
	internal class DateTimeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((long)reader.Value);
			return dt;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if ((value is DateTime) == false) throw new InvalidOperationException();

			writer.WriteValue(((DateTime)value).Second);
		}
	}
}
