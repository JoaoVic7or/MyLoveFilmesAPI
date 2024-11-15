namespace MyLoveFilmes.Domain.Entities
{
    public class Rating
    {
        public Rating()
        { }

        public Rating(long userId, long movieId, decimal rating) 
        {
            UserId = userId;
            MovieId = movieId;
            RatingValue = rating;
        }

        public long UserId { get; private set; }
        public long MovieId { get; private set; }
        public decimal RatingValue { get; private set; }

        public User User { get; private set; }
        public Movie Movie { get; private set; }
    }
}
