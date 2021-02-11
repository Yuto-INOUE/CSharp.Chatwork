using System;
using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json.Linq;

namespace CSharp.Chatwork.Endpoint
{
	public class Tasks : Endpoint
	{
		public Tasks(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<TaskModel> GetAsync(
			long accountId,
			long assignedByAccountId,
			TaskStatuses status)
		{
			return await GetHttpResponseAsync<TaskModel>(
				HttpMethod.Get,
				new ApiParameter
				{
					{ nameof(accountId), accountId },
					{ nameof(assignedByAccountId), assignedByAccountId },
					{ nameof(status), status },
				});
		}

		public async Task<CreatedTaskIdsModel> PostAsync(long[] toIds, string body, DateTime? limit = null, TaskLimitTypes? limitType = null)
		{
			return await GetHttpResponseAsync<CreatedTaskIdsModel>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(toIds), toIds },
					{ nameof(body), body },
					{ nameof(limit), limit },
					{ nameof(limitType), limitType },
				});
		}

		public TasksWithTaskId this[string taskId] => new TasksWithTaskId(this.Token, this.RoomId, taskId);

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks";
	}

	public class TasksWithTaskId : Endpoint
	{
		public TasksWithTaskId(ChatworkToken token, string roomId, string taskId) : base(token)
		{
			this.RoomId = roomId;
			this.TaskId = taskId;
		}

		public async Task<TaskModel> GetAsync()
		{
			return await GetHttpResponseAsync<TaskModel>(HttpMethod.Get);
		}

		private string RoomId { get; }
		private string TaskId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks/{this.TaskId}";
	}

	public class TaskStatus : Endpoint
	{
		public TaskStatus(ChatworkToken token, string roomId, string taskId) : base(token)
		{
			this.RoomId = roomId;
			this.TaskId = taskId;
		}

		public async Task<long> PutAsync(TaskStatuses body)
		{
			var json = await GetHttpResponseAsync<JToken>(
				HttpMethod.Put,
				new ApiParameter
				{
					{ nameof(body), body }
				});

			return json["task_id"].Value<long>();
		}

		private string RoomId { get; }
		private string TaskId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/tasks/{this.TaskId}/status";
	}
}
