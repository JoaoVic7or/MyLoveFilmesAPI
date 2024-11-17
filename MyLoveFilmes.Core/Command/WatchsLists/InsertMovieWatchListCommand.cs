using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.WatchsLists
{
    public class InsertMovieWatchListCommand : IRequest<Result>
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
