using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp.Chatwork.Endpoint
{
	public class Me : Endpoint
	{
		public Me(ChatworkToken token) : base(token)
		{
		}

		/// <summary>
		///     自分自身の情報を取得
		/// </summary>
		/// <returns>自分自身の情報</returns>
		public async Task<AccountModel> GetAsync()
		{
			return await GetHttpResponseAsync<AccountModel>(HttpMethod.Get);
		}

		protected override string EndPoint => "me";
	}
}
