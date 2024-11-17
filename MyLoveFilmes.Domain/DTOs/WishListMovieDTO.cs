namespace MyLoveFilmes.Domain.DTOs
{
    public class WishListMovieDTO
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public string MovieName { get; set; }
        public string PosterName { get; set; }
    }
}
