using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Users
{
    public class GetFavoritesMoviesByUserCommandHandler : IRequestHandler<GetFavoritesMoviesByUserCommand, Result<List<FavoriteMoviesDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;

        public GetFavoritesMoviesByUserCommandHandler(IMapper mapper, IFavoriteMoviesRepository favoriteMoviesRepository)
        {
            _mapper = mapper;
            _favoriteMoviesRepository = favoriteMoviesRepository;
        }

        public async Task<Result<List<FavoriteMoviesDTO>>> Handle(GetFavoritesMoviesByUserCommand command, CancellationToken cancellationToken)
        {
            List<FavoriteMovies> favoriteMovies = await _favoriteMoviesRepository.GetAllFavoritesMoviesByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<FavoriteMoviesDTO>>(favoriteMovies));
        }
    }
}
