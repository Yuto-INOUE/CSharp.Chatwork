namespace CSharp.Chatwork.Endpoint
{
	public class Rooms : Endpoint
	{
		public Rooms(ChatworkToken token) : base(token)
		{
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

		public Members Members => new Members(this.Token, this.RoomId);
		public Messages Messages => new Messages(this.Token, this.RoomId);
		public Tasks Tasks => new Tasks(this.Token, this.RoomId);
		public Files Files => new Files(this.Token, this.RoomId);

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}";
	}
}
