using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, Result>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsertCommentCommandHandler(ICommentRepository commentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _commentRepository = commentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result> Handle(InsertCommentCommand command, CancellationToken cancellationToken)
        {
            var userLogged = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (command.UserId.ToString() != userLogged.ToString())
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
