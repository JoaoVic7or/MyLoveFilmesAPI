using MediatR;
using Microsoft.AspNetCore.SignalR;
using MyLoveFilmes.Core.Command.Messages;
using MyLoveFilmes.Core.Hubs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Messages;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Messages
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Result>
	{
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IHubContext<ChatHub> chatHub, IMessageRepository messageRepository)
        {
            _chatHub = chatHub;
            _messageRepository = messageRepository;
        }

        public async Task<Result> Handle(SendMessageCommand command, CancellationToken cancellationToken)
		{
            try
            {
                Message message = new Message(command.Text, command.Date, command.UserId, command.ChatRoomId);

                await _messageRepository.AddMessage(message);

                //Notificar
                await _chatHub.Clients.Group(command.ChatRoomId.ToString())
                    .SendAsync("ReceiveMessage", new
                    {
                        UserId = message.UserId,
                        Message = message.Text,
                        SentAt = message.Date
                    });

                return Result.Success("Mensagem enviada!");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
	}
}

