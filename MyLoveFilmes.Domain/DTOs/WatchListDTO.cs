namespace MyLoveFilmes.Domain.DTOs
{
    public class WatchListDTO
    {
        public long MovieId { get; set; }
        public long UserId { get; set; }

        public string MovieName { get; set; }
        public string PosterName { get; set; }
    }
}
