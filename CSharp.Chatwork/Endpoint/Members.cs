namespace CSharp.Chatwork.Endpoint
{
	public class Members : Endpoint
	{
		public Members(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/members";
	}
}
