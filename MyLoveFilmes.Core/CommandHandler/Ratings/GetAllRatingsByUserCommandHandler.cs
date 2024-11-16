using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Ratings;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Ratings;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Ratings
{
    public class GetAllRatingsByUserCommandHandler : IRequestHandler<GetAllRatingsByUserCommand, Result<List<RatingDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;

        public GetAllRatingsByUserCommandHandler(IMapper mapper, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        public async Task<Result<List<RatingDTO>>> Handle(GetAllRatingsByUserCommand command, CancellationToken cancellationToken)
        {
            List<Rating> ratings = await _ratingRepository.GetAllRatingsByUserAsync(command.UserId);

            return Result.Ok(_mapper.Map<List<RatingDTO>>(ratings));
        }
    }
}
