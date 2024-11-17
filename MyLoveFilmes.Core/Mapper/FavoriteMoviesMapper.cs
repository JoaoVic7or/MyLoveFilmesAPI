using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class FavoriteMoviesMapper : Profile
    {
        public FavoriteMoviesMapper()
        {
            CreateMap<FavoriteMovies, FavoriteMoviesDTO>()
                .ForMember(dest => dest.MovieName, ori => ori.MapFrom(x => x.Movie.Name));
        }
    }
}
