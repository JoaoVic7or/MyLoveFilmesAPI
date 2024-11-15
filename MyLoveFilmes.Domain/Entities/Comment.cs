namespace MyLoveFilmes.Domain.Entities
{
    public class Comment
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public long MovieId { get; private set; }
        public string CommentText { get; private set; }
        public DateTime Date { get; private set; }

        public User User { get; private set; }
        public Movie Movie { get; private set; }
    }
}
