using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class RatingMapper : Profile
    {
        public RatingMapper() 
        {
            CreateMap<Rating, RatingDTO>();
        }
    }
}
