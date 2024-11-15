using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyLoveFIlmes.Middlewares
{
    public class JwtAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;

            if (path.StartsWithSegments("/css") || path.StartsWithSegments("/lib") || path.StartsWithSegments("/js") || path.StartsWithSegments("/images"))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Cookies["jwt"];

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken != null)
                {
                    var identity = new ClaimsIdentity(jsonToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    context.User = principal;

                    // Adicionando um claim adicional, se necessário
                    if (context.User.HasClaim(c => c.Type == JwtRegisteredClaimNames.Name))
                    {
                        var userNameClaim = context.User.FindFirst(JwtRegisteredClaimNames.Name);
                    }
                }
            }

            /*if (!context.User.Identity.IsAuthenticated)
            {
                if (!context.Request.Path.StartsWithSegments("/Login") &&
                    !context.Request.Path.StartsWithSegments("/Register"))
                {
                    context.Response.Redirect("/Login/Index");
                    return;
                }
            }*/

            await _next(context);
        }
    }
}
