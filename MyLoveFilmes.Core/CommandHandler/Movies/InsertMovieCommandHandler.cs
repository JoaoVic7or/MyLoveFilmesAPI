using MediatR;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class InsertMovieCommandHandler : IRequestHandler<InsertMovieCommand, Result>
    {
        private readonly IMovieRepository _movieRepository;

        public InsertMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result> Handle(InsertMovieCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Movie movie = new()
                {
                    Name = command.Name,
                    Director = command.Director,
                    ReleaseYear = command.ReleaseYear,
                    Synopsis = command.Synopsis,
                    MovieGenres = new List<MovieGenres>()
                };

                foreach (var genre in command.Genres)
                {
                    movie.MovieGenres.Add(new MovieGenres
                    {
                        GenreId = genre
                    });
                }

                if (command.ImagePoster != null)
                {
                    movie.Poster = new Poster()
                    {
                        Image = command.ImagePoster.FileName
                    };
                }

                await _movieRepository.InsertMovieAsync(movie, cancellationToken);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao adicionar o filme: ${ex.Message}");
            }
        }
    }
}
