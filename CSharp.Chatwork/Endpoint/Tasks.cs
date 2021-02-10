namespace CSharp.Chatwork.Endpoint
{
	public class Tasks : Endpoint
	{
		public Tasks(ChatworkToken token, string roomId)
			: base(token)
		{
			this.RoomId = roomId;
		}

		private string RoomId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks";
	}

	public class TasksWithTaskId : Endpoint
	{
		public TasksWithTaskId(ChatworkToken token, string roomId, string taskId)
			: base(token)
		{
			this.RoomId = roomId;
			this.TaskId = taskId;
		}

		private string RoomId { get; set; }
		private string TaskId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks/{this.TaskId}";
	}

	public class TaskStatus : Endpoint
	{
		public TaskStatus(ChatworkToken token, string roomId, string taskId)
			: base(token)
		{
			this.RoomId = roomId;
			this.TaskId = taskId;
		}

		private string RoomId { get; set; }
		private string TaskId { get; set; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks/{this.TaskId}/status";
	}
}
