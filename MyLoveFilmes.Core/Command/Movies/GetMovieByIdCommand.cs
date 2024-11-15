using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class GetMovieByIdCommand : IRequest<Result<MovieDTO>>
    {
        public long Id { get; set; }
    }
}
