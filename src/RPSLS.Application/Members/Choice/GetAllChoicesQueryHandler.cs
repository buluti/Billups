using RPSLS.Application.Abstractions;
using RPSLS.Application.Members.Choice.DTO;
using RPSLS.Domain.Entities.Enums;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Members.Choice;

internal sealed class GetAllChoicesQueryHandler : IQueryHandler<GetAllChoicesQuery, GameChoicesListResponse>

{
    public Task<Result<GameChoicesListResponse>> Handle(GetAllChoicesQuery request, CancellationToken cancellationToken)
    {
        GameChoicesListResponse list = new GameChoicesListResponse();

        foreach (RPSLSEnum value in Enum.GetValues(typeof(RPSLSEnum)))
        {
            list.Choices.Add(new GameChoiceResponse
            (
                (int)value,
                value.ToString().ToLower()
            ));
        }

        var result = Task.FromResult(Result.Success(list));
        return result;
    }
}
