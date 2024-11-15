using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Comments
{
    public class DeleteCommentCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
