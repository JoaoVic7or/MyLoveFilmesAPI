namespace MyLoveFilmes.Domain.DTOs
{
    public class FavoriteMoviesDTO
    {
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public string MovieName { get; set; }
    }
}
