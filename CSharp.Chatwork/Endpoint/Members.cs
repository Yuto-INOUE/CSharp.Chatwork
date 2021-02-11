using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;

namespace CSharp.Chatwork.Endpoint
{
	public class Members : Endpoint
	{
		public Members(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<ListedResponse<AccountModel>> GetAsync()
		{
			return await GetHttpResponseAsync<ListedResponse<AccountModel>>(HttpMethod.Get);
		}

		public async Task<RoomMemberIdsModel> PutAsync(
			long[] membersAdminIds,
			long[] membersMemberIds = null,
			long[] membersReadonlyIds = null)
		{
			return await GetHttpResponseAsync<RoomMemberIdsModel>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(membersAdminIds), membersAdminIds },
					{ nameof(membersMemberIds), membersMemberIds },
					{ nameof(membersReadonlyIds), membersReadonlyIds },
				});
		}

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/members";
	}
}
