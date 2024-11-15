using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Ratings
{
    public class GetRatingByUserCommand : IRequest<Result<RatingDTO>>
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
