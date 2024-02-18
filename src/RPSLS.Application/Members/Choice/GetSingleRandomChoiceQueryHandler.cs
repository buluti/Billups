using RPSLS.Application.Abstractions;
using RPSLS.Application.Members.Choice.DTO;
using RPSLS.Domain.Entities.Enums;
using RPSLS.Domain.Interfaces;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Members.Choice;

internal class GetSingleRandomChoiceQueryHandler : IQueryHandler<GetSingleRandomChoiceQuery, GameChoiceResponse>
{
    private readonly IRandomGameChoice _randomChoice;

    public GetSingleRandomChoiceQueryHandler(IRandomGameChoice randomChoice)
    {
        _randomChoice = randomChoice;
    }

    public async Task<Result<GameChoiceResponse>> Handle(
        GetSingleRandomChoiceQuery request,
        CancellationToken cancellationToken)
    {
        RPSLSEnum randomChoice = await _randomChoice.Generate();

        var choice = new GameChoiceResponse
        (
            (int)randomChoice,
            randomChoice.ToString().ToLower()
        );

        var result = Result.Success(choice);
        return result;
    }
}
