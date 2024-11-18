using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.FavoritesMovies
{
    public class GetFavoritesMoviesByUserCommand : IRequest<Result<List<FavoriteMoviesDTO>>>
    {
        public long UserId { get; set; }
    }
}
