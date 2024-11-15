using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        Task<User> GetEmailUsersAsync(string email);
        Task<User> GetUserByIdAsync(long userId);
        Task UpdateUserAsync(User user);
    }
}
