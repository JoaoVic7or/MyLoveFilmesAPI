using MediatR;
using MyLoveFilmes.Core.Command.WatchsLists;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.WatchsLists;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.WatchsLists
{
    public class InsertMovieWatchListCommandHandler : IRequestHandler<InsertMovieWatchListCommand, Result>
    {
        private readonly IUserContextService _userContext;
        private readonly IWatchListRepository _watchListRepository;

        public InsertMovieWatchListCommandHandler(IUserContextService userContext, IWatchListRepository watchListRepository)
        {
            _userContext = userContext;
            _watchListRepository = watchListRepository;
        }

        public async Task<Result> Handle(InsertMovieWatchListCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            bool alreadyHas = await _watchListRepository.UserAlreadyHasMovieInWatchListAsync(command.UserId, command.MovieId);

            if (alreadyHas)
                return Result.Fail("O filme já está na sua lista.");

            WatchList watchList = new WatchList(command.MovieId, command.UserId);

            try
            {
                await _watchListRepository.InsertMovieInWatchList(watchList);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao inserir filme na lista: ${ex.Message}");
            }
        }
    }
}
