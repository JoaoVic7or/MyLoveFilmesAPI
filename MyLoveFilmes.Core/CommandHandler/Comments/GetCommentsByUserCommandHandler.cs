using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCommentsByUserCommandHandler(IMapper mapper, ICommentRepository commentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<List<CommentDTO>>> Handle(GetCommentsByUserCommand command, CancellationToken cancellationToken)
        {
            var userLogged = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (command.UserId.ToString() != userLogged.ToString())
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            List<Comment> comments = await _commentRepository.GetCommentsByUser(command.UserId);

            return Result.Ok(_mapper.Map<List<CommentDTO>>(comments));
        }
    }
}
