﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class GetAllMoviesCommandHandler : IRequestHandler<GetAllMoviesCommand, Result<List<MovieDTO>>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "MovieList";

        public GetAllMoviesCommandHandler(IMovieRepository movieRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<Result<List<MovieDTO>>> Handle(GetAllMoviesCommand command, CancellationToken cancellationToken)
        {
            int page = command.Page > 0 ? command.Page : 1;
            int pageSize = command.PageSize > 0 ? command.PageSize : 5;

            string cacheKey = $"{CacheKey}_Page_{page}_PageSize_{pageSize}";

            if (_memoryCache.TryGetValue(cacheKey, out List<Movie> cachedMovies))
            {
                return Result.Ok(_mapper.Map<List<MovieDTO>>(cachedMovies));
            }

            List<Movie> movies = await _movieRepository.GetAllMovies(page, pageSize, cancellationToken);

            if (movies is null)
                return Result.BadRequest("Erro ao recuperar todos os filmes");

            _memoryCache.Set(CacheKey, movies, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });

            return Result.Ok(_mapper.Map<List<MovieDTO>>(movies));
        }
    }
}
