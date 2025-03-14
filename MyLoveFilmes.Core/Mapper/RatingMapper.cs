﻿using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class RatingMapper : Profile
    {
        public RatingMapper() 
        {
            CreateMap<Rating, RatingDTO>()
                .ForMember(dest => dest.MovieName, ori => ori.MapFrom(x => x.Movie.Name));
        }
    }
}
