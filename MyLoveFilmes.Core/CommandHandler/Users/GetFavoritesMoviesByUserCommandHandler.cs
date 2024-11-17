using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetFavoritesMoviesByUserCommandHandler(IMapper mapper, IFavoriteMoviesRepository favoriteMoviesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _favoriteMoviesRepository = favoriteMoviesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<List<FavoriteMoviesDTO>>> Handle(GetFavoritesMoviesByUserCommand command, CancellationToken cancellationToken)
        {
            var userLogged = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (command.UserId.ToString() != userLogged.ToString())
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            List<FavoriteMovies> favoriteMovies = await _favoriteMoviesRepository.GetAllFavoritesMoviesByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<FavoriteMoviesDTO>>(favoriteMovies));
        }
    }
}
