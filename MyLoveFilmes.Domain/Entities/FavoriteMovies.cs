namespace MyLoveFilmes.Domain.Entities
{
    public class FavoriteMovies
    {
        public long MovieId { get; private set; }
        public long UserId { get; private set; }

        public Movie Movie { get; private set; }
        public User User { get; private set; }

        public FavoriteMovies() { }

        public FavoriteMovies(long movieId, long userId)
        {
            MovieId = movieId;
            UserId = userId;
        }
    }
}
