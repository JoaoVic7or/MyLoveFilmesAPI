namespace MyLoveFilmes.Domain.Entities
{
    public class User
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int RoleId { get; private set; }

        public Roles Roles { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        public ICollection<Ratings> Ratings { get; private set; }
    }
}
