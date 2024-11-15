using MediatR;
using MyLoveFilmes.Core.Command.Ratings;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Ratings;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Ratings
{
    public class InsertRatingCommandHandler : IRequestHandler<InsertRatingCommand, Result>
    {
        private readonly IRatingRepository _ratingRepository;

        public InsertRatingCommandHandler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Result> Handle(InsertRatingCommand command, CancellationToken cancellationToken)
        {
            Rating userAlreadyHasRating = await _ratingRepository.GetRatingByUserId(command.UserId, command.MovieId);

            if (userAlreadyHasRating != null)
                return Result.Fail("Usuário já possui avaliação para esse filme.");

            Rating newRating = new(command.UserId, command.MovieId, command.Rating);

            try
            {
                await _ratingRepository.InsertRatingAsync(newRating);
                return Result.Success("Filme inserido com sucesso!");
            } 
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao avaliar o filme. {ex.Message}");
            }
        }
    }
}
