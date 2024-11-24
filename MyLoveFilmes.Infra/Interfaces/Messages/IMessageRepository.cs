using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.Messages
{
    public interface IMessageRepository
	{
        Task AddMessage(Message message);
    }
}

