namespace MyLoveFilmes.Domain.Entities
{
    public class WishListMovie
    {
        public long MovieId { get; private set; }
        public long UserId { get; private set; }

        public Movie Movie { get; private set; }
        public User User { get; private set; }
    }
}
