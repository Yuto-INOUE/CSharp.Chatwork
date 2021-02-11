using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;

namespace CSharp.Chatwork.Endpoint
{
	public class Link : Endpoint
	{
		public Link(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<LinkModel> GetAsync()
		{
			return await GetHttpResponseAsync<LinkModel>(HttpMethod.Get);
		}

		public async Task<LinkModel> PostAsync(
			string code = null,
			string description = null,
			bool? needAcceptance = null)
		{
			return await GetHttpResponseAsync<LinkModel>(
				HttpMethod.Post,
				new ApiParameter
				{
					{ nameof(code), code },
					{ nameof(description), description },
					{ nameof(needAcceptance), needAcceptance },
				});
		}

		public async Task<LinkModel> PutAsync(
			string code = null,
			string description = null,
			bool? needAcceptance = null)
		{
			return await GetHttpResponseAsync<LinkModel>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(code), code },
					{ nameof(description), description },
					{ nameof(needAcceptance), needAcceptance },
				});
		}

		public async Task DeleteAsync()
		{
			await SendHttpRequestAsync(HttpMethod.Delete);
		}

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/link";
	}
}
