using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.WatchsLists
{
    public class GetWatchListByUserCommand : IRequest<Result<List<WatchListDTO>>>
    {
        public long UserId { get; set; }
    }
}
