using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Genres
{
    public class GetAllGenresCommand : IRequest<Result<List<GenreDTO>>>
    { }
}
