namespace MyLoveFilmes.Domain.Entities
{
    public class MovieGenres
    {
        public long MovieId { get; set; }
        public long GenreId { get; set; }

        public Movie Movie { get; private set; }
        public Genre Genre { get; private set; }
    }
}
