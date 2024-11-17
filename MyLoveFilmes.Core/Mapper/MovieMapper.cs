using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.Poster, ori => ori.MapFrom(x => x.Poster.Image))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.RatingValue) : 0))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.MovieGenres.Select(x => x.Genre)));
        }
    }
}
