using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IFavoriteMoviesRepository
    {
        Task<List<FavoriteMovies>> GetAllFavoritesMoviesByUser(long userId);
    }
}
