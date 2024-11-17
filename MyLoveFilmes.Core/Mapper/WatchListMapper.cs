using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class WatchListMapper : Profile
    {
        public WatchListMapper()
        {
            CreateMap<WatchList, WatchListDTO>()
                .ForMember(dest => dest.MovieName, ori => ori.MapFrom(x => x.Movie.Name))
                .ForMember(dest => dest.PosterName, ori => ori.MapFrom(x => x.Movie.Poster.Image));
        }
    }
}
