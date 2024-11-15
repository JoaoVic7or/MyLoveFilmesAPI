namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IRoleRepository
    {
        Task<string> GetRolesByIdAsync(int roleId);
    }
}
