using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
	public class SearchMovieCommand : IRequest<Result<JsonResult>>
	{
		public string InputValue { get; set; }
	}
}

