using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.WatchsLists;

namespace MyLoveFilmes.Infra.Repositories.WatchsLists
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly AppDbContext _appDbContext;

        public WatchListRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<WatchList>> GetWatchListByUserAsync(long userId)
        {
            return await _appDbContext.WatchLists.Where(x => x.UserId == userId)
                                                 .Include(x => x.Movie)
                                                 .ThenInclude(x => x.Poster)
                                                 .AsNoTracking()
                                                 .ToListAsync();
        }

        public async Task<bool> UserAlreadyHasMovieInWatchListAsync(long userId, long movieId)
        {
            IQueryable<WatchList> watchLists = _appDbContext.WatchLists.Where(x => x.UserId == userId)
                                                                       .Where(x => x.MovieId == movieId)
                                                                       .AsQueryable();

            List<WatchList> list = await watchLists.AsNoTracking()
                                                   .ToListAsync();

            if (list.Count > 0)
                return true;

            return false;
        }

        public async Task InsertMovieInWatchList(WatchList watchList)
        {
            _appDbContext.WatchLists.Add(watchList);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteMovieFromWatchList(long userId, long movieId)
        {
            WatchList watchList = await GetMovieInWatchList(userId, movieId);

            if (watchList is null)
                throw new KeyNotFoundException();

            _appDbContext.WatchLists.Remove(watchList);
            await _appDbContext.SaveChangesAsync();
        }

        private async Task<WatchList> GetMovieInWatchList(long userId, long movieId)
        {
            return await _appDbContext.WatchLists.Where(x => x.UserId == userId)
                                                 .Where(x => x.MovieId == movieId)
                                                 .FirstOrDefaultAsync();
        }
    }
}
