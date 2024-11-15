using MediatR;
using Microsoft.AspNetCore.Http;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class UpdateMovieCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Synopsis { get; set; }
        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public IFormFile ImagePoster { get; set; }
        public decimal AverageRating { get; set; }
        public List<int> Genres { get; set; }
    }
}
