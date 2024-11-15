using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> GetRolesByIdAsync(int roleId)
        {
            return await _appDbContext.Roles
                                      .Where(x => x.Id == roleId)
                                      .Select(x => x.Name)
                                      .FirstOrDefaultAsync();
        }
    }
}
