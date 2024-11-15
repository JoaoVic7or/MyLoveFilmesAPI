namespace MyLoveFilmes.Domain.DTOs
{
    public class AuthResponseDTO
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string ErrorMessage { get; set; }
    }
}
