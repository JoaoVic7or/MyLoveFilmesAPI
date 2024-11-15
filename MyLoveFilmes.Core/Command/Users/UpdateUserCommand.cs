using MediatR;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Users
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
