using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.Comments
{
    public interface ICommentRepository
    {
        Task InsertCommentAsync(Comment comment, CancellationToken cancellationToken);
        Task DeleteCommentAsync(Comment comment, CancellationToken cancellationToken);
        Task<Comment> GetCommentByUserMovie(long id, long userId, long movieId);
    }
}
