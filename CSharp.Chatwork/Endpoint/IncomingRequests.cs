using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp.Chatwork.Endpoint
{
	public class IncomingRequests : Endpoint
	{
		public IncomingRequests(ChatworkToken token) : base(token)
		{
		}

		public async Task<ListedResponse<AccountModel>> GetAsync()
		{
			return await GetHttpResponseAsync<ListedResponse<AccountModel>>(HttpMethod.Get);
		}

		public IncomingRequestsWithRequestId this[string requestId] => new IncomingRequestsWithRequestId(this.Token, requestId);
		protected override string EndPoint => "incoming_requests";
	}

	public class IncomingRequestsWithRequestId : Endpoint
	{
		public IncomingRequestsWithRequestId(ChatworkToken token, string requestId) : base(token)
		{
			this.RequestId = requestId;
		}

		public async Task<AccountModel> PutAsync()
		{
			return await GetHttpResponseAsync<AccountModel>(HttpMethod.Put);
		}

		public async Task DeleteAsync()
		{
			await SendHttpRequestAsync(HttpMethod.Put);
		}

		private string RequestId { get; }
		protected override string EndPoint => $"incoming_requests/{this.RequestId}";
	}
}
