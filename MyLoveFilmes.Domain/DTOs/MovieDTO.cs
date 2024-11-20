using Microsoft.AspNetCore.Http;

namespace MyLoveFilmes.Domain.DTOs
{
    public class MovieDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Synopsis { get; set; }
        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public IFormFile ImagePoster { get; set; }

        public decimal AverageRating { get; set; }

        public string Poster { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
