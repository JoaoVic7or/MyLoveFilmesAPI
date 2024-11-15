using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IAuthRepository 
    {
        Task<User?> GetUserByEmail(string email);
    }
}
