using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Ratings
{
    public class InsertRatingCommand : IRequest<Result>
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public decimal Rating { get; set; }
    }
}
