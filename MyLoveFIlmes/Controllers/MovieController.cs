using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Core.Command.Movies;

namespace MyLoveFIlmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMoviesAsync([FromQuery]GetAllMoviesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
