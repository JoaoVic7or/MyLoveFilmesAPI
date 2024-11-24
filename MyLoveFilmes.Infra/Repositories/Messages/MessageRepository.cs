using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Messages;

namespace MyLoveFilmes.Infra.Repositories.Messages
{
    public class MessageRepository : IMessageRepository
	{
		private readonly AppDbContext _appDbContext;

		public MessageRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task AddMessage(Message message)
		{
			_appDbContext.Messages.Add(message);
			await _appDbContext.SaveChangesAsync();
		}
	}
}

