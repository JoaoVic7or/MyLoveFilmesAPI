namespace MyLoveFilmes.Domain.Entities
{
    public class Genre
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public List<MovieGenres> MovieGenres { get; private set; }
    }
}
