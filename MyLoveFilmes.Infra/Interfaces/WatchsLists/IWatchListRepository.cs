using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.WatchsLists
{
    public interface IWatchListRepository
    {
        Task<List<WatchList>> GetWatchListByUserAsync(long userId);
        Task<bool> UserAlreadyHasMovieInWatchListAsync(long userId, long movieId);
        Task InsertMovieInWatchList(WatchList watchList);
        Task DeleteMovieFromWatchList(long userId, long movieId);
    }
}
