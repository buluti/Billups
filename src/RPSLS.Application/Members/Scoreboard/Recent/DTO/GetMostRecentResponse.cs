namespace RPSLS.Application.Members.Scoreboard.Recent.DTO;

public sealed record GetMostRecentResponse(
    string result,
    int player,
    int computer,
    string time);