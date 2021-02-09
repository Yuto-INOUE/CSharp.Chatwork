using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharp.Chatwork.Endpoint
{
	public abstract class Endpoint
	{
		private static readonly HttpClient _httpClient = new HttpClient();
		private const string BASE_URI = "https://api.chatwork.com/v2/";

		protected Endpoint(ChatworkToken token)
		{
			this.Token = token;
		}

		internal async Task SendRequestAsync(HttpMethod method, ApiParameter param = null)
		{
			await ExecAsync(method, param);
		}

		internal async Task<T> GetResponseAsync<T>(HttpMethod method, ApiParameter param = null)
		{
			return JsonConvert.DeserializeObject<T>(await ExecAsync(method, param));
		}

		private async Task<string> ExecAsync(HttpMethod method, ApiParameter param = null)
		{
			var message = new HttpRequestMessage
			{
				Headers =
				{
					{ "X-ChatWorkToken", this.Token.ApiKey }
				},
				Method = method
			};

			var url = BASE_URI + this.EndPoint;
			if (ShouldAppendQueryString(method) && param != null)
			{
				url += $"?{param.ToQuery()}";
			}
			message.RequestUri = new Uri(url);

			if (ShouldSendContent(method))
			{
				message.Content = new StringContent(param?.ToQuery() ?? string.Empty, Encoding.UTF8);
			}

			var response = await _httpClient.SendAsync(message);
			var responseContent = await response.Content.ReadAsStringAsync();
			if (!response.StatusCode.IsSuccessStatusCode())
			{
				var errors = (JArray)JsonConvert.DeserializeObject<JToken>(responseContent)["errors"];
				throw new ChatworkException(errors.Cast<string>().ToArray(), (int)response.StatusCode);
			}

			return responseContent;
		}

		private bool ShouldAppendQueryString(HttpMethod method)
		{
			switch (method.Method)
			{
				case "GET":
					return true;

				default:
					return false;
			}
		}

		private bool ShouldSendContent(HttpMethod method)
		{
			return !ShouldAppendQueryString(method);
		}

		private ChatworkToken Token { get; set; }
		private string EndPoint => throw new NotSupportedException();
	}
}
