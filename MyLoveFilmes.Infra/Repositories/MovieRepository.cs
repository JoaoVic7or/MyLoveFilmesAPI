using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;

namespace MyLoveFilmes.Infra.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Movie>> GetAllMovies(int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Movie> query = _appDbContext.Movies.AsQueryable();

            return await query.Include(x => x.Poster)
                              .Include(x => x.MovieGenres)
                              .ThenInclude(y => y.Genre)
                              .OrderByDescending(x => x.ReleaseYear)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .AsNoTracking()
                              .ToListAsync(cancellationToken);
        }

        public async Task<List<Movie>> GetMoviesRandom(CancellationToken cancellationToken)
        {
            IQueryable<Movie> query = _appDbContext.Movies;

            return await query.Include(x => x.Poster)
                              .Include(x => x.MovieGenres)
                              .ThenInclude(y => y.Genre)
                              .Where(x => x.Poster != null)
                              .OrderByDescending(x => x.ReleaseYear)
                              .Take(16)
                              .ToListAsync(cancellationToken);
        }

        public async Task<Movie> GetMovieById(long id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Movies.Where(x => x.Id == id)
                                             .Include(x => x.Poster)
                                             .Include(x => x.Comments)
                                             .ThenInclude(x => x.User)
                                             .Include(x => x.Ratings)
                                             .Include(x => x.MovieGenres)
                                             .ThenInclude(y => y.Genre)
                                             .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task InsertMovieAsync(Movie movie, CancellationToken cancellationToken)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            var existingMovie = await _appDbContext.Movies
                .FirstOrDefaultAsync(m => m.Name.ToUpper() == movie.Name.ToUpper(), cancellationToken);

            if (existingMovie != null)
                throw new InvalidOperationException("Filme já existe na base de dados");

            await _appDbContext.Movies.AddAsync(movie, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateMovieAsync(Movie movie, CancellationToken cancellationToken)
        {
            var existingMovie = await _appDbContext.Movies
                                                   .Include(m => m.MovieGenres) 
                                                   .FirstOrDefaultAsync(m => m.Id == movie.Id, cancellationToken);

            if (existingMovie == null)
                throw new KeyNotFoundException("Filme não foi localizado.");

            // Update properties
            existingMovie.Name = movie.Name;
            existingMovie.Synopsis = movie.Synopsis;
            existingMovie.Director = movie.Director;
            existingMovie.ReleaseYear = movie.ReleaseYear;

            // Update poster if provided
            if (movie.Poster != null)
            {
                existingMovie.Poster = movie.Poster;
            }

            // Handle genre updates
            var currentGenreIds = existingMovie.MovieGenres.Select(mg => mg.GenreId).ToList();
            var newGenreIds = movie.MovieGenres.Select(mg => mg.GenreId).ToList();

            // Remove unchecked genres
            foreach (var genreId in currentGenreIds.Except(newGenreIds))
            {
                var genreToRemove = existingMovie.MovieGenres.First(mg => mg.GenreId == genreId);
                _appDbContext.MovieGenres.Remove(genreToRemove);
            }

            // Add new checked genres
            foreach (var genreId in newGenreIds.Except(currentGenreIds))
            {
                existingMovie.MovieGenres.Add(new MovieGenres { MovieId = existingMovie.Id, GenreId = genreId });
            }

            // Save changes
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public List<Movie> GetMovieByName(string name)
        {
            IQueryable<Movie> query = _appDbContext.Movies.Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                                                          .AsQueryable();

            List<Movie> movies = query.AsNoTracking()
                                      .ToList();

            return movies;
        }
    }
}
