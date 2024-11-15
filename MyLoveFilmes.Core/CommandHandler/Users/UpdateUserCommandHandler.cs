using MediatR;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetEmailUsersAsync(command.Email);

            bool isPasswordvalid = BCrypt.Net.BCrypt.Verify(command.OldPassword, command.NewPassword);

            if (!isPasswordvalid)
                return Result.Fail("A senha antiga não está correta.");

            user.UpdatePassword(BCrypt.Net.BCrypt.HashPassword(command.NewPassword));

            try
            {
                await _userRepository.UpdateUserAsync(user);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao atualizar a senha: ${ex.Message}");
            }
        }
    }
}
