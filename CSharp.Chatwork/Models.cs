using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	public class ListedResponse<T> : IResponse, ICollection<T>
	{
		public ListedResponse()
		{
			this.InnerList = new List<T>();
		}

		public ListedResponse(IEnumerable<T> collection)
		{
			this.InnerList = collection.ToList();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T item)
		{
			this.InnerList.Add(item);
		}

		public void Clear()
		{
			this.InnerList.Clear();
		}

		public bool Contains(T item)
		{
			return this.InnerList.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			this.InnerList.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return this.InnerList.Remove(item);
		}

		public int Count => this.InnerList.Count;
		public bool IsReadOnly => false;

		private List<T> InnerList { get; }
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

	public class MessageModel : Response
	{
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		[JsonProperty("account")]
		public AccountModel Account { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("send_time")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime SendTime { get; set; }

		[JsonProperty("update_time")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime UpdateTime { get; set; }
	}

	public class RoomModel : Response
	{
		[JsonProperty("room_id")]
		public long RoomId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public RoomTypes Type { get; set; }

		[JsonProperty("role")]
		[JsonConverter(typeof(StringEnumConverter))]
		public RoomRoles Role { get; set; }

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

		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("limit_time")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime LimitTime { get; set; }

		[JsonProperty("status")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TaskStatuses Status { get; set; }

		[JsonProperty("limit_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TaskLimitTypes LimitType { get; set; }
	}

	public class FileModel : Response
	{
		[JsonProperty("file_id")]
		public long FileId { get; set; }

		[JsonProperty("account")]
		public AccountModel Account { get; set; }

		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		[JsonProperty("filename")]
		public string FileName { get; set; }

		[JsonProperty("filesize")]
		public long FileSize { get; set; }

		[JsonProperty("upload_time")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime UploadTime { get; set; }
	}

	public class LinkModel : Response
	{
		[JsonProperty("public")]
		public bool Public { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("need_acceptance")]
		public bool NeedAcceptance { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
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

	public class RoomMemberIdsModel
	{
		[JsonProperty("admin")]
		public long[] Admin { get; set; }

		[JsonProperty("member")]
		public long[] Member { get; set; }

		[JsonProperty("readonly")]
		public long[] Readonly { get; set; }
	}

	public class RoomReadStatusModel
	{
		[JsonProperty("unread_num")]
		public int UnreadNum { get; set; }

		[JsonProperty("mention_num")]
		public int MentionNum { get; set; }
	}

	public class CreatedTaskIdsModel : Response, IEnumerable<long>
	{
		public IEnumerator<long> GetEnumerator()
		{
			return this.TaskIds.AsEnumerable()?.GetEnumerator() ?? throw new InvalidOperationException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[JsonProperty("task_ids")]
		public long[] TaskIds { get; set; }
	}

	internal class ApiErrorModel : Response
	{
		public static explicit operator string[](ApiErrorModel model)
		{
			return model.Errors;
		}

		[JsonProperty("errors")]
		public string[] Errors { get; set; }
	}

	public enum TaskStatuses
	{
		Open,
		Done
	}

	public enum TaskLimitTypes
	{
		Date,
		Time
	}

	public enum RoomTypes
	{
		My,
		Direct,
		Group
	}

	public enum RoomRoles
	{
		ReadOnly = 0,
		Member = 1,
		Admin = 2
	}

	public enum RoomIconPresets
	{
		Group,
		Check,
		Document,
		Meeting,
		Event,
		Project,
		Business,
		Study,
		Security,
		Star,
		Idea,
		Heart,
		Magcup,
		Beer,
		Music,
		Sports,
		Travel
	}

	public enum RoomDeleteActionTypes
	{
		Leave,
		Delete,
	}
}