namespace MyLoveFilmes.Domain.Entities
{
    public class Movie
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public string? Synopsis { get;  set; }
        public string? Director { get;  set; }
        public int? ReleaseYear { get;  set; }

        public Poster Poster { get;  set; }
        public List<MovieGenres> MovieGenres { get;  set; }

        public List<Comment> Comments { get;  set; }
        public List<Ratings> Ratings { get;  set; }
    }
}
