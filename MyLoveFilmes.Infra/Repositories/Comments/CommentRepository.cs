using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;

namespace MyLoveFilmes.Infra.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InsertCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            _appDbContext.Comments.Add(comment);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            _appDbContext.Comments.Remove(comment);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Comment> GetCommentByUserMovie(long id, long userId, long movieId)
        {
            return await _appDbContext.Comments.Where(x => x.Id == id)
                                               .Where(x => x.UserId == userId)
                                               .Where(x => x.MovieId == movieId)
                                               .FirstOrDefaultAsync();
        }
    }
}
