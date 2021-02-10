namespace CSharp.Chatwork.Endpoint
{
	public class Files : Endpoint
	{
		public Files(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/files";
	}

	public class FilesWithFileId : Endpoint
	{
		public FilesWithFileId(ChatworkToken token, string roomId, string fileId)
			: base(token)
		{
			this.RoomId = roomId;
			this.FileId = fileId;
		}

		private string RoomId { get; set; }
		private string FileId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/files/{this.FileId}";
	}

}
