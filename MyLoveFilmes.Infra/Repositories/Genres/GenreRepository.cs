using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Genres;

namespace MyLoveFilmes.Infra.Repositories.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
        {
            IQueryable<Genre> query = _appDbContext.Genres
                                                   .OrderBy(x => x.Name)
                                                   .AsQueryable();
            
            return await query.AsNoTracking()
                              .ToListAsync(cancellationToken);
        }
    }
}
