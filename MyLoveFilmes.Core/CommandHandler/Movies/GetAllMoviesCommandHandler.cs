using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class GetAllMoviesCommandHandler : IRequestHandler<GetAllMoviesCommand, List<MovieDTO>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetAllMoviesCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDTO>> Handle(GetAllMoviesCommand command, CancellationToken cancellationToken)
        {
            List<Movie> movies = await _movieRepository.GetAllMovies(cancellationToken);

            return _mapper.Map<List<MovieDTO>>(movies); ;
        }
    }
}
