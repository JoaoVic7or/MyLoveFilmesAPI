using MediatR;
using MyLoveFilmes.Core.Command.WatchsLists;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Infra.Interfaces.WatchsLists;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.WatchsLists
{
    public class DeleteMovieFromWatchListCommandHandler : IRequestHandler<DeleteMovieFromWatchListCommand, Result>
    {
        private readonly IUserContextService _userContext;
        private readonly IWatchListRepository _watchListRepository;

        public DeleteMovieFromWatchListCommandHandler(IUserContextService userContext, IWatchListRepository watchListRepository)
        {
            _userContext = userContext;
            _watchListRepository = watchListRepository;
        }

        public async Task<Result> Handle(DeleteMovieFromWatchListCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            bool alreadyHas = await _watchListRepository.UserAlreadyHasMovieInWatchListAsync(command.UserId, command.MovieId);

            if (!alreadyHas)
                return Result.Fail("O filme não está presente na sua lista.");

            try
            {
                await _watchListRepository.DeleteMovieFromWatchList(command.UserId, command.MovieId);
                return Result.Success("Filme removido da lista com sucesso!");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao inserir filme na lista: ${ex.Message}");
            }
        }
    }
}
