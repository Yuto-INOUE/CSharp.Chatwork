namespace CSharp.Chatwork.Endpoint
{
	public class Messages : Endpoint
	{
		public Messages(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages";
	}

	public class MessagesRead : Endpoint
	{
		public MessagesRead(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/read";
	}

	public class MessagesUnread : Endpoint
	{
		public MessagesUnread(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/unread";
	}

	public class MessagesWithMessageId : Endpoint
	{
		public MessagesWithMessageId(ChatworkToken token, string roomId, string messageId)
			: base(token)
		{
			this.RoomId = roomId;
			this.MessageId = messageId;
		}

		private string RoomId { get; set; }
		private string MessageId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/messages/{this.MessageId}";
	}
}
