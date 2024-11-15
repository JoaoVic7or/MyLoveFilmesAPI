using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class GetRandomMoviesCommand : IRequest<Result<List<MovieDTO>>>
    { }
}
