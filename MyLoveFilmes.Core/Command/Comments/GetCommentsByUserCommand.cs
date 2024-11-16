using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Comments
{
    public class GetCommentsByUserCommand : IRequest<Result<List<CommentDTO>>>
    {
        public long UserId { get; set; }
    }
}
