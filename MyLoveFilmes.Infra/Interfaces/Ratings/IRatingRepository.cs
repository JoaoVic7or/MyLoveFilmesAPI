using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.Ratings
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByUserId(long userId, long movieId);
        Task InsertRatingAsync(Rating rating);
        Task<List<Rating>> GetAllRatingsByUserAsync(long userId);
    }
}
