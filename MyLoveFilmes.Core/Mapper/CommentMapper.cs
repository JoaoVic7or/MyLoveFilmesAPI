using AutoMapper;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;

namespace MyLoveFilmes.Core.Mapper
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.MovieName, ori => ori.MapFrom(x => x.Movie.Name));
        }
    }
}
