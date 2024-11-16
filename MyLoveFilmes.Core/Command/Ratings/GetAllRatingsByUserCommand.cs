using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Ratings
{
    public class GetAllRatingsByUserCommand : IRequest<Result<List<RatingDTO>>>
    {
        public long UserId { get; set; }
    }
}
