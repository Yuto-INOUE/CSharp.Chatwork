using CSharp.Chatwork.Endpoint;

namespace CSharp.Chatwork
{
	public class ChatworkToken
	{
		public static ChatworkToken Create(string apiKey)
		{
			return new ChatworkToken
			{
				ApiKey = apiKey
			};
		}

		/// <summary>
		///     自分自身の情報にアクセスできます。
		/// </summary>
		public Me Me => new Me(this);

		/// <summary>
		///     自分が持つデータへアクセスできます。
		/// </summary>
		public My My => new My(this);

		/// <summary>
		///     自分のコンタクトになっているユーザーの一覧にアクセスできます。
		/// </summary>
		public Contacts Contacts => new Contacts(this);

		/// <summary>
		///     グループチャット、ダイレクトチャット、マイチャットなどのチャット全体をあらわすエンドポイントです。
		///     チャットにひもづくメッセージ、タスク、ファイル、概要、メンバー情報などにアクセスできます。
		/// </summary>
		public Rooms Rooms => new Rooms(this);

		/// <summary>
		///     自分に対するコンタクト承認依頼データにアクセスできます。
		/// </summary>
		public IncomingRequests IncomingRequests => new IncomingRequests(this);

		internal string ApiKey { get; set; }
	}
}
