using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json.Linq;

namespace CSharp.Chatwork.Endpoint
{
	public class Messages : Endpoint
	{
		public Messages(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<ListedResponse<MessageModel>> GetAsync(bool? force = null)
		{
			return await GetHttpResponseAsync<ListedResponse<MessageModel>>(
				HttpMethod.Get,
				new ApiParameter
				{
					{ nameof(force), force }
				});
		}

		public async Task<string> PostAsync(string body, bool? selfUnread = null)
		{
			var json = await GetHttpResponseAsync<JToken>(
				HttpMethod.Post,
				new ApiParameter
				{
					{ nameof(body), body },
					{ nameof(selfUnread), selfUnread },
				});
			return (string)json["message_id"];
		}

		public MessagesRead Read => new MessagesRead(this.Token, this.RoomId);
		public MessagesUnread Unread => new MessagesUnread(this.Token, this.RoomId);

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages";
	}

	public class MessagesRead : Endpoint
	{
		public MessagesRead(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<RoomReadStatusModel> PutAsync(string messageId = null)
		{
			return await GetHttpResponseAsync<RoomReadStatusModel>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(messageId), messageId }
				});
		}

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/read";
	}

	public class MessagesUnread : Endpoint
	{
		public MessagesUnread(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<RoomReadStatusModel> PutAsync(string messageId = null)
		{
			return await GetHttpResponseAsync<RoomReadStatusModel>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(messageId), messageId }
				});
		}

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/unread";
	}

	public class MessagesWithMessageId : Endpoint
	{
		public MessagesWithMessageId(ChatworkToken token, string roomId, string messageId) : base(token)
		{
			this.RoomId = roomId;
			this.MessageId = messageId;
		}

		public async Task<MessageModel> GetAsync()
		{
			return await GetHttpResponseAsync<MessageModel>(HttpMethod.Get);
		}

		public async Task<string> PutAsync()
		{
			var json = await GetHttpResponseAsync<JToken>(HttpMethod.Put);
			return (string)json["message_id"];
		}

		public async Task<string> DeleteAsync()
		{
			var json = await GetHttpResponseAsync<JToken>(HttpMethod.Delete);
			return (string)json["message_id"];
		}

		private string RoomId { get; }
		private string MessageId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/{this.MessageId}";
	}
}
