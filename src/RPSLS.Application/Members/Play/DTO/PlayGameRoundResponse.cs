namespace RPSLS.Application.Members.Play.DTO;

public sealed record PlayGameRoundResponse(
    string result,
    int player,
    int computer);
