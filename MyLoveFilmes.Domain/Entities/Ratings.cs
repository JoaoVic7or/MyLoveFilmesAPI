namespace MyLoveFilmes.Domain.Entities
{
    public class Ratings
    {
        public long UserId { get; private set; }
        public long MovieId { get; private set; }
        public decimal Rating { get; private set; }

        public User User { get; private set; }
        public Movie Movie { get; private set; }
    }
}
