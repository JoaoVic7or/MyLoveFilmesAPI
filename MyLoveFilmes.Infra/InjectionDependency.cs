using Microsoft.Extensions.DependencyInjection;
using MyLoveFilmes.Infra.Interfaces;
using MyLoveFilmes.Infra.Interfaces.Comments;
using MyLoveFilmes.Infra.Interfaces.Ratings;
using MyLoveFilmes.Infra.Repositories;
using MyLoveFilmes.Infra.Repositories.Comments;
using MyLoveFilmes.Infra.Repositories.Ratings;

namespace MyLoveFilmes.Infra
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddRepositoriesApplication(this IServiceCollection services)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
