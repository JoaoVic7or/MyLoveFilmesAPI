namespace MyLoveFilmes.Domain.DTOs
{
    public class CommentDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public UserDTO User { get; set; }

        public string MovieName { get; set; }
    }
}
