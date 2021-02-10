using System.Net.Http;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;

namespace CSharp.Chatwork.Endpoint
{
	public class My : Endpoint
	{
		public My(ChatworkToken token) : base(token)
		{
		}

		public MyStatus Status => new MyStatus(this.Token);
		public MyTasks Task => new MyTasks(this.Token);
	}

	public class MyStatus : Endpoint
	{
		public MyStatus(ChatworkToken token) : base(token)
		{
		}

		public async Task<MyStatusModel> GetAsync()
		{
			return await GetHttpResponseAsync<MyStatusModel>(HttpMethod.Get);
		}

		protected override string EndPoint => "my/status";
	}

	public class MyTasks : Endpoint
	{
		public MyTasks(ChatworkToken token) : base(token)
		{
		}

		public async Task<ListedResponse<TaskModel>> GetAsync(int? assignedByAccountId = null, TaskStatus? status = null)
		{
			return await GetHttpResponseAsync<ListedResponse<TaskModel>>(
				HttpMethod.Get,
				new ApiParameter
				{
					{ nameof(assignedByAccountId), assignedByAccountId },
					{ nameof(status), status }
				});
		}

		protected override string EndPoint => "my/tasks";
	}
}
