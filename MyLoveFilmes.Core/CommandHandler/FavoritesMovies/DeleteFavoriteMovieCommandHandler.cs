using MediatR;
using MyLoveFilmes.Core.Command.FavoritesMovies;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.FavoritesMovies
{
    public class DeleteFavoriteMovieCommandHandler : IRequestHandler<DeleteFavoriteMovieCommand, Result>
    {
        private readonly IUserContextService _userContext;
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;

        public DeleteFavoriteMovieCommandHandler(IUserContextService userContext, IFavoriteMoviesRepository favoriteMoviesRepository)
        {
            _userContext = userContext;
            _favoriteMoviesRepository = favoriteMoviesRepository;
        }

        public async Task<Result> Handle(DeleteFavoriteMovieCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            FavoriteMovies favoriteMovies = await _favoriteMoviesRepository.GetFavorieMovieByUser(command.UserId, command.MovieId);

            if (favoriteMovies == null)
                return Result.Fail("Erro: Esse filme não está na sua lista.");

            try
            {
                await _favoriteMoviesRepository.DeleteFavoriteMovieAsync(favoriteMovies);
                return Result.Success("Filme deletado da sua lista com sucesso");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro: ${ex.Message}");
            }
        }
    }
}
