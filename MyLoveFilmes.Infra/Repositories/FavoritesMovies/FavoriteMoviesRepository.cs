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
    }
}
