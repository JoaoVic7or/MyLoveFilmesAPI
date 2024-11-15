using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class GetMovieByIdCommandHandler : IRequestHandler<GetMovieByIdCommand, Result<MovieDTO>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieByIdCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<Result<MovieDTO>> Handle(GetMovieByIdCommand command, CancellationToken cancellationToken)
        {
            Movie movie = await _movieRepository.GetMovieById(command.Id, cancellationToken);

            if (movie is null)
                return Result.NotFound("Filme não localizado");

            return Result.Ok(_mapper.Map<MovieDTO>(movie));
        }
    }
}
