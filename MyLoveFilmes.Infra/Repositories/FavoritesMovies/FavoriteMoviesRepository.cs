using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Infra.Repositories.FavoritesMovies
{
    public class FavoriteMoviesRepository : IFavoriteMoviesRepository
    {
        private readonly AppDbContext _appDbContext;

        public FavoriteMoviesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<FavoriteMovies>> GetAllFavoritesMoviesByUser(long userId)
        {
            return await _appDbContext.FavoriteMovies.Where(x => x.UserId == userId)
                                                     .Include(x => x.Movie)
                                                     .AsNoTracking()
                                                     .ToListAsync();
        }

        public async Task InsertFavoriteMovie(FavoriteMovies favoritesMovies)
        {
            _appDbContext.FavoriteMovies.Add(favoritesMovies);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<FavoriteMovies> GetFavorieMovieByUser(long userId, long movieId)
        {
            return await _appDbContext.FavoriteMovies.Where(x => x.UserId == userId)
                                                     .Where(x => x.MovieId == movieId)
                                                     .FirstOrDefaultAsync();
        }

        public async Task DeleteFavoriteMovieAsync(FavoriteMovies favoriteMovies)
        {
            _appDbContext.FavoriteMovies.Remove(favoriteMovies);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
