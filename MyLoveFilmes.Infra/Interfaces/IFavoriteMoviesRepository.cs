using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IFavoriteMoviesRepository
    {
        Task<List<FavoriteMovies>> GetAllFavoritesMoviesByUser(long userId);
        Task InsertFavoriteMovie(FavoriteMovies favoritesMovies);
        Task<FavoriteMovies> GetFavorieMovieByUser(long userId, long movieId);
        Task DeleteFavoriteMovieAsync(FavoriteMovies favoriteMovies);
    }
}
