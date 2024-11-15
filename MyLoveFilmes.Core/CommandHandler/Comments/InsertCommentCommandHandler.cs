using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, Result>
    {
        private readonly ICommentRepository _commentRepository;

        public InsertCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result> Handle(InsertCommentCommand command, CancellationToken cancellationToken)
        {
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
