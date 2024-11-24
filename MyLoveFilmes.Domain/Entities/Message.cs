namespace MyLoveFilmes.Domain.Entities
{
    public class Message
	{
		public long Id { get; private set; }
		public string Text { get; private set; }
		public DateTime Date { get; private set; } = DateTime.UtcNow;
		public long UserId { get; private set; }
		public long ChatRoomId { get; private set; }

		public User User { get; private set; }

		public Message(string text, DateTime date, long userId, long chatRoomId)
		{
			Text = text;
			Date = date;
			UserId = userId;
			ChatRoomId = chatRoomId;
		}

		public void NotificateMessage(long userId, string text, DateTime date)
		{
			UserId = userId;
			Text = text;
			Date = date;
		}
	}
}

