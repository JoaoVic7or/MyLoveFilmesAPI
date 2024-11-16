using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class GetCommentsByUserCommandHandler : IRequestHandler<GetCommentsByUserCommand, Result<List<CommentDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentsByUserCommandHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<CommentDTO>>> Handle(GetCommentsByUserCommand command, CancellationToken cancellationToken)
        {
            List<Comment> comments = await _commentRepository.GetCommentsByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<CommentDTO>>(comments));
        }
    }
}
