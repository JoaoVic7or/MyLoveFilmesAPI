using Microsoft.EntityFrameworkCore;
using MyLoveFilmes.Domain.Entities;
using System.Reflection;

namespace MyLoveFilmes.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasSequence<int>("usuarios_id_seq")
                        .StartsAt(1)
                        .IncrementsBy(1);

            modelBuilder.Entity<User>()
                        .Property(x => x.Id)
                        .HasDefaultValueSql("nextval('usuarios_id_seq')");

            modelBuilder.HasSequence<int>("movie_poster_id_seq")
                        .StartsAt(1)
                        .IncrementsBy(1);

            modelBuilder.Entity<Poster>()
                        .Property(x => x.Id)
                        .HasDefaultValueSql("nextval('movie_poster_id_seq')");

            modelBuilder.HasSequence<int>("movies_id_seq")
                        .StartsAt(1)
                        .IncrementsBy(1);

            modelBuilder.Entity<Movie>()
                        .Property(x => x.Id)
                        .HasDefaultValueSql("nextval('movies_id_seq')");

            modelBuilder.HasSequence<long>("tb_users_comments_commentid_seq")
                        .StartsAt(1)
                        .IncrementsBy(1);

            modelBuilder.Entity<Comment>()
                        .Property(x => x.Id)
                        .HasDefaultValueSql("nextval('tb_users_comments_commentid_seq')");

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<FavoriteMovies> FavoriteMovies { get; set; }
        public DbSet<WishListMovie> WishListMovies { get; set; }
    }
}
