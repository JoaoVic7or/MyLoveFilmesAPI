using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _userContext;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUserContextService userContext)
        {
            _userRepository = userRepository;
            _userContext = userContext;
        }

        public async Task<Result> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.Id.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            User user = await _userRepository.GetEmailUsersAsync(command.Email);

            bool isPasswordvalid = BCrypt.Net.BCrypt.Verify(command.OldPassword, command.NewPassword);

            if (!isPasswordvalid)
                return Result.Fail("A senha antiga não está correta.");

            user.UpdatePassword(BCrypt.Net.BCrypt.HashPassword(command.NewPassword));

            try
            {
                await _userRepository.UpdateUserAsync(user);
                return Result.Success("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao atualizar a senha: ${ex.Message}");
            }
        }
    }
}
