using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Movies
{
    public class SearchMovieCommandHandler : IRequestHandler<SearchMovieCommand, Result<JsonResult>>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public SearchMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<Result<JsonResult>> Handle(SearchMovieCommand command, CancellationToken cancellationToken)
		{
			List<Movie> movies = await _movieRepository.GetMovieByName(command.InputValue);

			if (movies == null)
				return Result.Ok(new JsonResult(new { message = "Filme não localizado" }));

			List<MovieDTO> movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

			return Result.Ok(new JsonResult(movieDTOs));
		}
	}
}

