using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.FavoritesMovies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;
using MyLoveFilmes.Core.Services.Interfaces;

namespace MyLoveFilmes.Core.CommandHandler.FavoritesMovies
{
    public class GetFavoritesMoviesByUserCommandHandler : IRequestHandler<GetFavoritesMoviesByUserCommand, Result<List<FavoriteMoviesDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;
        private readonly IUserContextService _userContext;

        public GetFavoritesMoviesByUserCommandHandler(IMapper mapper, IFavoriteMoviesRepository favoriteMoviesRepository, IUserContextService userContext)
        {
            _mapper = mapper;
            _favoriteMoviesRepository = favoriteMoviesRepository;
            _userContext = userContext;
        }

        public async Task<Result<List<FavoriteMoviesDTO>>> Handle(GetFavoritesMoviesByUserCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            List<FavoriteMovies> favoriteMovies = await _favoriteMoviesRepository.GetAllFavoritesMoviesByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<FavoriteMoviesDTO>>(favoriteMovies));
        }
    }
}
