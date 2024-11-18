using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Movies;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Roles;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        public MovieController(IMediator meditator) : base(meditator) { }

        [AllowAnonymous]
        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMoviesAsync([FromQuery] GetAllMoviesCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [AllowAnonymous]
        [HttpGet("GetMovieById")]
        public async Task<IActionResult> GetMovieByIdAsync([FromQuery] GetMovieByIdCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [AllowAnonymous]
        [HttpGet("GetRandomMovies")]
        public async Task<IActionResult> GetRandomMoviesAsync([FromQuery] GetRandomMoviesCommand command) //mudar banco
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize(Roles = Permissions.Administrator)]
        [HttpPost("InsertMovie")]
        public async Task<IActionResult> InsertMovieAsync([FromBody] InsertMovieCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize(Roles = Permissions.Administrator)]
        [HttpPatch("UpdateMovie")]
        public async Task<IActionResult> UpdateMovieAsync([FromBody] UpdateMovieCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [AllowAnonymous]
        [HttpGet("GetMovieByName")]
        public async Task<IActionResult> SearchMovie([FromQuery] SearchMovieCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
