using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharp.Chatwork.Endpoint
{
	public class Files : Endpoint
	{
		public Files(ChatworkToken token, string roomId) : base(token)
		{
			this.RoomId = roomId;
		}

		public async Task<ListedResponse<FileModel>> GetAsync(long? accountId = null)
		{
			return await GetHttpResponseAsync<ListedResponse<FileModel>>(
				HttpMethod.Get,
				new ApiParameter
				{
					{ nameof(accountId), accountId }
				});
		}

		public async Task<long> PostAsync(string file, string message = null)
		{
			await using var stream = File.OpenRead(file);
			var request = new HttpRequestMessage(HttpMethod.Post, BASE_URI + this.EndPoint)
			{
				Content = new MultipartFormDataContent
				{
					{ new StreamContent(stream), "file", Path.GetFileName(file) },
					{ new StringContent(message, Encoding.UTF8), "message" }
				},
				Headers =
				{
					{ "X-ChatWorkToken", this.Token.ApiKey }
				}
			};

			var response = await _httpClient.SendAsync(request);
			return JsonConvert.DeserializeObject<JToken>(await response.Content.ReadAsStringAsync())["file_id"].Value<long>();
		}

		public FilesWithFileId this[string fileId] => new FilesWithFileId(this.Token, this.RoomId, fileId);

		private string RoomId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/files";
	}

	public class FilesWithFileId : Endpoint
	{
		public FilesWithFileId(ChatworkToken token, string roomId, string fileId) : base(token)
		{
			this.RoomId = roomId;
			this.FileId = fileId;
		}

		public async Task<FileModel> GetAsync(bool createDownloadUrl)
		{
			return await GetHttpResponseAsync<FileModel>(
				HttpMethod.Get,
				new ApiParameter
				{
					{ nameof(createDownloadUrl), createDownloadUrl }
				});
		}

		private string RoomId { get; }
		private string FileId { get; }
		protected override string EndPoint => $"rooms/{this.RoomId}/files/{this.FileId}";
	}
}
