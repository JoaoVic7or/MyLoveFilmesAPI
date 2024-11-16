using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Infra.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies(int page, int pageSize, CancellationToken cancellationToken);
        Task<List<Movie>> GetMoviesRandom(CancellationToken cancellationToken);
        Task InsertMovieAsync(Movie movie, CancellationToken cancellationToken);
        Task<Movie> GetMovieById(long id, CancellationToken cancellationToken);
        Task UpdateMovieAsync(Movie movie, CancellationToken cancelToken);

        List<Movie> GetMovieByName(string name);
    }
}
