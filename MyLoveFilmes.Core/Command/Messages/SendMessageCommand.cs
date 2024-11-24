using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Messages
{
	public class SendMessageCommand : IRequest<Result>
	{
		public long UserId { get; set; }
		public string Text { get; set; }
        public long ChatRoomId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}

