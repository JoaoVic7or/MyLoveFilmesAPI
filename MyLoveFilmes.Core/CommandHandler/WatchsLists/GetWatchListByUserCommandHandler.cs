using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.WatchsLists;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.WatchsLists;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.WatchsLists
{
    public class GetWatchListByUserCommandHandler : IRequestHandler<GetWatchListByUserCommand, Result<List<WatchListDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IWatchListRepository _watchListRepository;
        private readonly IUserContextService _userContext;

        public GetWatchListByUserCommandHandler(IMapper mapper, IWatchListRepository watchListRepository, IUserContextService userContext)
        {
            _mapper = mapper;
            _watchListRepository = watchListRepository;
            _userContext = userContext;
        }

        public async Task<Result<List<WatchListDTO>>> Handle(GetWatchListByUserCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            List<WatchList> watchLists = await _watchListRepository.GetWatchListByUserAsync(command.UserId);

            return Result.Ok(_mapper.Map<List<WatchListDTO>>(watchLists));
        }
    }
}
