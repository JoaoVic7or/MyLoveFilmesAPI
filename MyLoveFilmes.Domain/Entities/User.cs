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
        public ICollection<Rating> Ratings { get; private set; }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public User()
        { }

        public User(string name, string email, string password, int roleId)
        {
            Name = name;
            Password = password;
        }
    }
}
