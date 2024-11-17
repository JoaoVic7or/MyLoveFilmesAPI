namespace MyLoveFilmes.Domain.Entities
{
    public class WatchList
    {
        public long MovieId { get; private set; }
        public long UserId { get; private set; }

        public Movie Movie { get; private set; }
        public User User { get; private set; }

        public WatchList() { }

        public WatchList(long movieId, long userId)
        {
            MovieId = movieId;
            UserId = userId;
        }
    }
}
