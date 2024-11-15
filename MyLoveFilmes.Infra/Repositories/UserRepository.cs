using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task RegisterUserAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetEmailUsersAsync(string email)
        {
            return await _appDbContext.Users.Where(x => x.Email.ToUpper() == email.ToUpper())
                                            .Include(x => x.Roles)
                                            .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            return await _appDbContext.Users.Where(x => x.Id == userId)
                                            .Include(x => x.Roles)
                                            .FirstOrDefaultAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
