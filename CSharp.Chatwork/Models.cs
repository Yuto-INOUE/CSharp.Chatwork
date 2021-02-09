using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

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

	public class AccountModel
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
}
