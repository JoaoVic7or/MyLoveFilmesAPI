using MediatR;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            User userEmail = await _userRepository.GetEmailUsersAsync(command.Email);

            if (userEmail != null)
                return Result.Fail("Esse e-mail já está cadastrado, por favor faça o login.");

            User user = new User(command.Name, command.Email, BCrypt.Net.BCrypt.HashPassword(command.Password), 1);

            try
            {
                await _userRepository.RegisterUserAsync(user);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao registrar: ${ex.Message}");
            }
        }
    }
}
