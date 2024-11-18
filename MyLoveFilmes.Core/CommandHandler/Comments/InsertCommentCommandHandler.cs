using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, Result>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserContextService _userContext;

        public InsertCommentCommandHandler(ICommentRepository commentRepository, IUserContextService userContext)
        {
            _commentRepository = commentRepository;
            _userContext = userContext;
        }

        public async Task<Result> Handle(InsertCommentCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            Comment comment = new(command.Id, command.UserId, command.MovieId, command.CommentText, command.Date);

            try
            {
                await _commentRepository.InsertCommentAsync(comment, cancellationToken);
                return Result.Success("Comentário inserido com sucesso!");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao inserir comentário: ${ex.Message}");
            }
        }
    }
}
