using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
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
