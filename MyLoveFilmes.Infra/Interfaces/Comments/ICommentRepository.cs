using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.Comments
{
    public interface ICommentRepository
    {
        Task InsertCommentAsync(Comment comment, CancellationToken cancellationToken);
    }
}
