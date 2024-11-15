using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Ratings;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Ratings;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Ratings
{
    public class GetRatingByUserCommandHandler : IRequestHandler<GetRatingByUserCommand, Result<RatingDTO>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetRatingByUserCommandHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<Result<RatingDTO>> Handle(GetRatingByUserCommand command, CancellationToken cancellationToken)
        {
            Rating rating = await _ratingRepository.GetRatingByUserId(command.UserId, command.MovieId);

            if (rating is null)
                return Result.NotFound();

            return Result.Ok(_mapper.Map<RatingDTO>(rating));
        }
    }
}
