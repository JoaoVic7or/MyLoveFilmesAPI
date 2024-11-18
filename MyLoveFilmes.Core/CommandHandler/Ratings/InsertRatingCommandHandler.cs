using MediatR;
using MyLoveFilmes.Core.Command.Ratings;
using MyLoveFilmes.Core.Services.Interfaces;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces.Ratings;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Core.CommandHandler.Ratings
{
    public class InsertRatingCommandHandler : IRequestHandler<InsertRatingCommand, Result>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserContextService _userContext;

        public InsertRatingCommandHandler(IRatingRepository ratingRepository, IUserContextService userContext)
        {
            _ratingRepository = ratingRepository;
            _userContext = userContext;
        }

        public async Task<Result> Handle(InsertRatingCommand command, CancellationToken cancellationToken)
        {
            string userLogged = _userContext.GetUserLogged();

            if (command.UserId.ToString() != userLogged)
                return Result.Unauthorized("Você não tem permissão para realizar esta ação.");

            Rating userAlreadyHasRating = await _ratingRepository.GetRatingByUserId(command.UserId, command.MovieId);

            if (userAlreadyHasRating != null)
                return Result.Fail("Usuário já possui avaliação para esse filme.");

            Rating newRating = new(command.UserId, command.MovieId, command.Rating);

            try
            {
                await _ratingRepository.InsertRatingAsync(newRating);
                return Result.Success("Avaliação enviada!");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro ao avaliar o filme. {ex.Message}");
            }
        }
    }
}
