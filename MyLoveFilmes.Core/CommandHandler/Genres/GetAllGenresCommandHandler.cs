using AutoMapper;
using MediatR;
using MyLoveFilmes.Core.Command.Genres;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Genres;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Genres
{
    public class GetAllGenresCommandHandler : IRequestHandler<GetAllGenresCommand, Result<List<GenreDTO>>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetAllGenresCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GenreDTO>>> Handle(GetAllGenresCommand command, CancellationToken cancellationToken) 
        {
            List<Genre> genres = await _genreRepository.GetAllGenresAsync(cancellationToken);

            return Result.Ok(_mapper.Map<List<GenreDTO>>(genres));
        }
    }
}
