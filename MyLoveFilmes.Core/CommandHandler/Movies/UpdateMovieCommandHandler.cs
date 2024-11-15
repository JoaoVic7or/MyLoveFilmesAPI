using MediatR;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Result>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            Movie movie = new()
            {
                Name = command.Name,
                Director = command.Director,
                ReleaseYear = command.ReleaseYear,
                Synopsis = command.Synopsis,
                MovieGenres = new List<MovieGenres>()
            };

            if (command.ImagePoster != null)
            {
                movie.Poster = new Poster()
                {
                    Image = command.ImagePoster.FileName
                };
            }

            try
            {
                await _movieRepository.UpdateMovieAsync(movie, cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao atualizar o filme: ${ex.Message}");
            }
        }
    }
}
