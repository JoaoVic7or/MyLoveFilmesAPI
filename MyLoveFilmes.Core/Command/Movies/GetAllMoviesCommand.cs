using MediatR;
using MyLoveFilmes.Domain.DTOs;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class GetAllMoviesCommand : IRequest<List<MovieDTO>>
    {
    }
}
