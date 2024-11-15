using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Ratings;

namespace MyLoveFilmes.Infra.Repositories.Ratings
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _appDbContext;

        public RatingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Rating> GetRatingByUserId(long userId, long movieId)
        {
            return _appDbContext.Ratings.Where(x => x.UserId == userId)
                                        .Where(x => x.MovieId == movieId)
                                        .FirstOrDefaultAsync();
        }

        public async Task InsertRatingAsync(Rating rating)
        {
            _appDbContext.Ratings.Add(rating);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
