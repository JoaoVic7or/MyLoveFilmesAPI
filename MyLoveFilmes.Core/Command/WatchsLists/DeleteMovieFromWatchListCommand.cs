using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.WatchsLists
{
    public class DeleteMovieFromWatchListCommand : IRequest<Result>
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
