namespace MyLoveFilmes.Domain.Entities
{
    public class Poster
    {
        public long Id { get; private set; }
        public long MovieId { get; private set; }
        public string Image { get; private set; }

        public Movie Movie { get; private set; }
    }
}
