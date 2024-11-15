namespace MyLoveFilmes.Domain.Entities
{
    public class Roles
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<User> Users { get; private set; }
    }
}
