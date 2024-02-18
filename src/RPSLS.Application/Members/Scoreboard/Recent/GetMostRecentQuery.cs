using RPSLS.Application.Abstractions;
using RPSLS.Application.Members.Scoreboard.Recent.DTO;

namespace RPSLS.Application.Members.Scoreboard.Recent;

public sealed record GetMostRecentQuery(int ResultsToShow) : IQuery<List<GetMostRecentResponse>>;
