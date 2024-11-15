using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Comments
{
    public class InsertCommentCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
    }
}
