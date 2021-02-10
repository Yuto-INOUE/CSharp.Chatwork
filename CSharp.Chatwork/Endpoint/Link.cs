namespace CSharp.Chatwork.Endpoint
{
	public class Link : Endpoint
	{
		public Link(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/link";
	}
}
