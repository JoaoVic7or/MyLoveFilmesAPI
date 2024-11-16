namespace MyLoveFilmes.Domain.DTOs
{
    public class RatingDTO
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public decimal RatingValue { get; set; }

        public string MovieName { get; set; }   
    }
}
