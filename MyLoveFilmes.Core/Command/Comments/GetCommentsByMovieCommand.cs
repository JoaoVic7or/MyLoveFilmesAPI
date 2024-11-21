using System;
using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Comments
{
	public class GetCommentsByMovieCommand : IRequest<Result<List<CommentDTO>>>
	{
		public long MovieId { get; set; }
	}
}

