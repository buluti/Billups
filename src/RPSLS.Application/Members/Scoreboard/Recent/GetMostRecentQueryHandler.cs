using RPSLS.Application.Abstractions;
using RPSLS.Application.Members.Scoreboard.Recent;
using RPSLS.Application.Members.Scoreboard.Recent.DTO;
using RPSLS.Domain.Entities;
using RPSLS.Domain.Interfaces;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Scoreboard.Recent.Choice;

internal sealed class GetMostRecentQueryHandler : IQueryHandler<GetMostRecentQuery, List<GetMostRecentResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoundRepository _roundRepository;

    public GetMostRecentQueryHandler(IRoundRepository roundRepository, IUnitOfWork unitOfWork)
    {
        _roundRepository = roundRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetMostRecentResponse>>> Handle(
        GetMostRecentQuery request,
        CancellationToken cancellationToken)
    {
        List<Round> list = await _roundRepository.GetLatestResultsAsync(request.ResultsToShow);

        List<GetMostRecentResponse> prettyList = new List<GetMostRecentResponse>();
        foreach (var x in list)
        {
            prettyList.Add(new GetMostRecentResponse(
                x.Result.ToString().ToLower(),
                (int)x.Player,
                (int)x.Computer,
                x.CreatedAtUtc.ToLongDateString()));
        }

        return prettyList;
    }
}
