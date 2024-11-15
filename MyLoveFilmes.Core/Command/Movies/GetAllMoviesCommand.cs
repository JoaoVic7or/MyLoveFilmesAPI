﻿using MediatR;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.Command.Movies
{
    public class GetAllMoviesCommand : IRequest<Result<List<MovieDTO>>>
    { }
}
