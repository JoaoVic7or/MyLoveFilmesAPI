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
    }
}
