using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Users
{
    public class GetWishListMoviesByUserCommand : IRequest<Result<List<WishListMovieDTO>>>
    {
        public long UserID { get; set; }
    }
}
