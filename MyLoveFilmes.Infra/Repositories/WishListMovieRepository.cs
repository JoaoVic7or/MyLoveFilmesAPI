using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Infra.Repositories
{
    public class WishListMovieRepository : IWishListMovieRepository
    {
        private readonly AppDbContext _appDbContext;

        public WishListMovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<WishListMovie>> GetUserWishListAsync(long userId)
        {
            return await _appDbContext.WishListMovies.Where(x => x.UserId == userId)
                                                     .AsNoTracking()
                                                     .ToListAsync();
        }
    }
}
