namespace RPSLS.Application.Members.Choice.DTO;

public sealed record GameChoicesListResponse
{
    public List<GameChoiceResponse> Choices { get; set; } = new List<GameChoiceResponse>();
}
