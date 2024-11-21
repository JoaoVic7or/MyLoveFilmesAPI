using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Comments
{
    public class GetCommentsByMovieCommandHandler : IRequestHandler<GetCommentsByMovieCommand, Result<List<CommentDTO>>>
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public GetCommentsByMovieCommandHandler(ICommentRepository commentRepository, IMapper mapper)
		{
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public async Task<Result<List<CommentDTO>>> Handle(GetCommentsByMovieCommand command, CancellationToken cancellationToken)
		{
			List<Comment> comments = await _commentRepository.GetCommentsByMovieAsync(command.MovieId);

			return Result.Ok(_mapper.Map<List<CommentDTO>>(comments));
		}
	}
}

