using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Genres;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseController
    {
        public GenreController(IMediator mediator) : base(mediator) { }

        [AllowAnonymous]
        [HttpGet("GetAllGenres")]
        public async Task<IActionResult> GetAllGenresAsync([FromQuery] GetAllGenresCommand command) 
        {
            Result result = await _mediator.Send(command);
            
            return ResultHelper.AsResult(result);
        }
    }
}
