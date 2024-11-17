namespace MyLoveFilmes.Domain.Entities
{
    public class Poster
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Image { get; set; }

        public Movie Movie { get; private set; }
        public List<WishListMovie> WishListMovie { get; private set; }
    }
}
