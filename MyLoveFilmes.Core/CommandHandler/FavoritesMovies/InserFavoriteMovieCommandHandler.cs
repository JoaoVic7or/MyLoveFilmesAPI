using MediatR;
using MyLoveFilmes.Core.Command.FavoritesMovies;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.FavoritesMovies
{
    public class InsertFavoriteMovieCommandHandler : IRequestHandler<InsertFavoriteMovieCommand, Result>
    {
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;
        private readonly IUserContextService _userContext;

        public InsertFavoriteMovieCommandHandler(IFavoriteMoviesRepository favoriteMoviesRepository, IUserContextService userContext)
        {
            _favoriteMoviesRepository = favoriteMoviesRepository;
            _userContext = userContext;
        }

        public async Task<Result> Handle(InsertFavoriteMovieCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            FavoriteMovies hasFavoriteMovies = await _favoriteMoviesRepository.GetFavorieMovieByUser(command.UserId, command.MovieId);

            if (hasFavoriteMovies != null)
                return Result.Fail("Erro, o filme já está na lista.");

            FavoriteMovies favoriteMovies = new FavoriteMovies(command.MovieId, command.UserId);

            try
            {
                await _favoriteMoviesRepository.InsertFavoriteMovie(favoriteMovies);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao inserir o filme na lista: ${ex.Message}");
            }
        }
    }
}
