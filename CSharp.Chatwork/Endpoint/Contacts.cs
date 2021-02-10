using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp.Chatwork.Endpoint
{
	public class Contacts : Endpoint
	{
		public Contacts(ChatworkToken token)
			: base(token)
		{
		}

		public async Task<ListedResponse<AccountModel>> GetAsync()
		{
			return await GetHttpResponseAsync<ListedResponse<AccountModel>>(HttpMethod.Get);
		}

		protected override string EndPoint => "incoming_requests";
	}
}
