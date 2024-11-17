using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Users
{
    public class GetFavoritesMoviesByUserCommand : IRequest<Result<List<FavoriteMoviesDTO>>>
    {
        public long UserId { get; set; }
    }
}
