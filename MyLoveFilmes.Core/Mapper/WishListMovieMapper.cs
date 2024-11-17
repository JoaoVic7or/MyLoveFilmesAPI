using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class WishListMovieMapper : Profile
    {
        public WishListMovieMapper()
        {
            CreateMap<WishListMovie, WishListMovieDTO>()
                .ForMember(dest => dest.MovieName, ori => ori.MapFrom(x => x.Movie.Name));
        }
    }
}
