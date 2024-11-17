using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Users
{
    public class GetWishListMoviesByUserCommandHandler : IRequestHandler<GetWishListMoviesByUserCommand, Result<List<WishListMovieDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IWishListMovieRepository _wishListMovieRepository;

        public GetWishListMoviesByUserCommandHandler(IMapper mapper, IWishListMovieRepository wishListMovieRepository)
        {
            _mapper = mapper;
            _wishListMovieRepository = wishListMovieRepository;
        }

        public async Task<Result<List<WishListMovieDTO>>> Handle(GetWishListMoviesByUserCommand command, CancellationToken cancellationToken)
        {
            List<WishListMovie> wishListMovies = await _wishListMovieRepository.GetUserWishListAsync(command.UserID);

            return Result.Ok(_mapper.Map<List<WishListMovieDTO>>(wishListMovies));
        }
    }
}
