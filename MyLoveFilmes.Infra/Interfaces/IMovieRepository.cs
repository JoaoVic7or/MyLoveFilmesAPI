using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Shared.Domain.DataTable;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IMovieRepository
    {
        Task<DataGridView<Movie>> GetAllMovies(int page, int pageSize, CancellationToken cancellationToken, int draw);
        Task<List<Movie>> GetMoviesRandom(CancellationToken cancellationToken);
        Task InsertMovieAsync(Movie movie, CancellationToken cancellationToken);
        Task<Movie> GetMovieById(long id, CancellationToken cancellationToken);
        Task UpdateMovieAsync(Movie movie, CancellationToken cancelToken);

        Task<List<Movie>> GetMovieByName(string name);
    }
}
