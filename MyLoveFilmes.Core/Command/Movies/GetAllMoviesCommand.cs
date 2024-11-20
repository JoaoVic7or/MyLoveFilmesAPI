using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.DataTable;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class GetAllMoviesCommand : IRequest<Result<DataGridView<MovieDTO>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Draw { get; set; }
        public string? SearchValue { get; set; }
    }
}
