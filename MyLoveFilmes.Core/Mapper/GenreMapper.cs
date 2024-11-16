using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class GenreMapper : Profile
    {
        public GenreMapper()
        {
            CreateMap<Genre, GenreDTO>();
        }
    }
}
