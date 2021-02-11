using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json.Linq;

namespace CSharp.Chatwork.Endpoint
{
	public class Rooms : Endpoint
	{
		public Rooms(ChatworkToken token) : base(token)
		{
		}

		public async Task<ListedResponse<RoomModel>> GetAsync()
		{
			return await GetHttpResponseAsync<ListedResponse<RoomModel>>(HttpMethod.Get);
		}

		public async Task<string> PostAsync(
			string name,
			long[] membersAdminIds,
			long[] membersMemberIds = null,
			long[] membersReadonlyIds = null,
			string description = null,
			RoomIconPresets? iconPreset = null,
			bool? link = null,
			string linkCode = null,
			bool? linkNeedAcceptance = null)
		{
			var json = await GetHttpResponseAsync<JToken>(
				HttpMethod.Post,
				new ApiParameter
				{
					{ nameof(description), description },
					{ nameof(iconPreset), iconPreset },
					{ nameof(link), link },
					{ nameof(linkCode), linkCode },
					{ nameof(linkNeedAcceptance), linkNeedAcceptance },
					{ nameof(membersAdminIds), membersAdminIds },
					{ nameof(membersMemberIds), membersMemberIds },
					{ nameof(membersReadonlyIds), membersReadonlyIds },
					{ nameof(name), name },
				});
			return (string)json["room_id"];
		}

		public RoomsWithRoomId this[string roomId] => new RoomsWithRoomId(this.Token, roomId);
		protected override string EndPoint => "rooms";
	}

	public class RoomsWithRoomId : Endpoint
	{
		public RoomsWithRoomId(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<RoomModel> GetAsync()
		{
			return await GetHttpResponseAsync<RoomModel>(HttpMethod.Get);
		}

		public async Task DeleteAsync(RoomDeleteActionTypes actionType)
		{
			await SendHttpRequestAsync(
				HttpMethod.Delete,
				new ApiParameter
				{
					{ nameof(actionType), actionType }
				});
		}

		public Members Members => new Members(this.Token, this.RoomId);
		public Messages Messages => new Messages(this.Token, this.RoomId);
		public Tasks Tasks => new Tasks(this.Token, this.RoomId);
		public Files Files => new Files(this.Token, this.RoomId);
		public Link Link => new Link(this.Token, this.RoomId);

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}";
	}
}
