using System;
using System.Collections;
using System.Collections.Generic;
using CSharp.Chatwork.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CSharp.Chatwork
{
	public interface IResponse
	{
	}

	public abstract class Response : IResponse
	{
	}

	public class ListedResponse<T> : IResponse, IReadOnlyList<T>
	{
		public ListedResponse(List<T> collection)
		{
			this.InnerList = collection;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private List<T> InnerList { get; set; }
		public int Count { get; }
		public T this[int index] => this.InnerList[index];
	}

	public class AccountModel : Response
	{
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		[JsonProperty("room_id")]
		public long RoomId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("chatwork_id")]
		public string ChatworkId { get; set; }

		[JsonProperty("organization_id")]
		public long OrganizationId { get; set; }

		[JsonProperty("organization_name")]
		public string OrganizationName { get; set; }

		[JsonProperty("department")]
		public string Department { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("introduction")]
		public string Introduction { get; set; }

		[JsonProperty("mail")]
		public string Mail { get; set; }

		[JsonProperty("tel_organization")]
		public string TelOrganization { get; set; }

		[JsonProperty("tel_extension")]
		public string TelExtension { get; set; }

		[JsonProperty("tel_mobile")]
		public string TelMobile { get; set; }

		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("facebook")]
		public string Facebook { get; set; }

		[JsonProperty("twitter")]
		public string Twitter { get; set; }

		[JsonProperty("avatar_image_url")]
		public string AvatarImageUrl { get; set; }

		[JsonProperty("login_mail")]
		public string LoginMail { get; set; }
	}

	public class RoomModel : Response
	{
		[JsonProperty("room_id")]
		public long RoomId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public RoomType Type { get; set; }

		[JsonProperty("role")]
		[JsonConverter(typeof(StringEnumConverter))]
		public RoomRole Role { get; set; }

		[JsonProperty("sticky")]
		public bool Sticky { get; set; }

		[JsonProperty("unread_num")]
		public int UnreadNum { get; set; }

		[JsonProperty("mention_num")]
		public int MentionNum { get; set; }

		[JsonProperty("mytask_num")]
		public int MyTaskNum { get; set; }

		[JsonProperty("message_num")]
		public int MessageNum { get; set; }

		[JsonProperty("file_num")]
		public int FileNum { get; set; }

		[JsonProperty("task_num")]
		public int TaskNum { get; set; }

		[JsonProperty("icon_path")]
		public string IconPath { get; set; }

		[JsonProperty("last_update_time")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime LastUpdateTime { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}

	public class TaskModel : Response
	{
		[JsonProperty("task_id")]
		public long TaskId { get; set; }

		[JsonProperty("room")]
		public RoomModel Room { get; set; }

		[JsonProperty("assigned_by_account")]
		public AccountModel AssignedByAccount { get; set; }

		[JsonProperty("task_id")]
		public long MessageId { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("task_id")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime LimitTime { get; set; }

		[JsonProperty("task_id")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TaskStatus Status { get; set; }

		[JsonProperty("limit_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TaskLimitType LimitType { get; set; }
	}

	public class MyStatusModel : Response
	{
		[JsonProperty("unread_room_num")]
		public int UnreadRoomNum { get; set; }

		[JsonProperty("mention_room_num")]
		public int MentionRoomNum { get; set; }

		[JsonProperty("mytask_room_num")]
		public int MyTaskRoomNum { get; set; }

		[JsonProperty("unread_num")]
		public int UnreadNum { get; set; }

		[JsonProperty("mention_num")]
		public int MentionNum { get; set; }

		[JsonProperty("mytask_num")]
		public int MyTaskNum { get; set; }
	}

	public enum TaskStatus
	{
		Open,
		Done,
	}

	public enum TaskLimitType
	{
		Date,
		Time,
	}

	public enum RoomType
	{
		My,
		Direct,
		Group,
	}

	public enum RoomRole
	{
		ReadOnly = 0,
		Member = 1,
		Admin = 2,
	}
}
