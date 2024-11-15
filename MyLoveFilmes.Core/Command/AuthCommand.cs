using MediatR;
using MyLoveFilmes.Domain.DTOs;

namespace MyLoveFilmes.Core.Command
{
    public class AuthCommand : IRequest<AuthResponseDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
