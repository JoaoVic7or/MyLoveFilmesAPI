using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class GetRandomMoviesCommandHandler : IRequestHandler<GetRandomMoviesCommand, Result<List<MovieDTO>>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetRandomMoviesCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<MovieDTO>>> Handle(GetRandomMoviesCommand command, CancellationToken cancellationToken)
        {
            List<Movie> movies = await _movieRepository.GetMoviesRandom(cancellationToken);

            if (movies is null)
                return Result.BadRequest("Erro ao buscar os filmes");

            return Result.Ok(_mapper.Map<List<MovieDTO>>(movies));
        }
    }
}
