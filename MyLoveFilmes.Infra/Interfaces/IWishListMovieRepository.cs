using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IWishListMovieRepository
    {
        Task<List<WishListMovie>> GetUserWishListAsync(long userId);
    }
}
