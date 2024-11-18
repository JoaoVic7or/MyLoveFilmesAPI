using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.FavoritesMovies
{
    public class DeleteFavoriteMovieCommand : IRequest<Result>
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
