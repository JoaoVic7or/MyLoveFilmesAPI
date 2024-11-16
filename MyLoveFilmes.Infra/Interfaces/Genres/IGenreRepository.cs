using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces.Genres
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken);
    }
}
