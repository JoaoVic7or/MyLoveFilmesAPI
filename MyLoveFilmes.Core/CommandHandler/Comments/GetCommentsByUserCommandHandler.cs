using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Core.Services.Interfaces;
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
        private readonly IUserContextService _userContext;

        public GetCommentsByUserCommandHandler(IMapper mapper, ICommentRepository commentRepository, IUserContextService userContext)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Result<List<CommentDTO>>> Handle(GetCommentsByUserCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            List<Comment> comments = await _commentRepository.GetCommentsByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<CommentDTO>>(comments));
        }
    }
}
