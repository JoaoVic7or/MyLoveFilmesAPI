using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserContextService _userContext;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IUserContextService userContext)
        {
            _commentRepository = commentRepository;
            _userContext = userContext;
        }

        public async Task<Result> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            Comment comment = await _commentRepository.GetCommentByUserMovie(command.Id, command.UserId, command.MovieId);

            if (comment == null)
                return Result.NotFound("Eror ao apagar comentário: comentário não existe.");

            try
            {
                await _commentRepository.DeleteCommentAsync(comment, cancellationToken);
                return Result.Success("Comentário removido com sucesso.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao apagar o comentário: ${ex.Message}");
            }
        }
    }
}
