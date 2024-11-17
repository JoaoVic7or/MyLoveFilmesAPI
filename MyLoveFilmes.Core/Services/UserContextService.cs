using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyLoveFilmes.Core.Services.Interfaces;

namespace MyLoveFilmes.Core.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserLogged()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
