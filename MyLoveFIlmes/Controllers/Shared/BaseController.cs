using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyLoveFilmes.Controllers.Shared
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected long GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return long.Parse(userId);
        }
    }
}
