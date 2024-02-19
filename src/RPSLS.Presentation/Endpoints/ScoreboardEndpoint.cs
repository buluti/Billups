using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RPSLS.Application.Members.Scoreboard.Recent;
using RPSLS.Application.Scoreboard.Reset;

namespace RPSLS.Presentation.Endpoints;

public static class ScoreboardEndpoint
{
    public static void AddScoreboardModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tenmostrecent", GetTenMostRecent);
        app.MapDelete("/reset", ResetScoreboard);
    }

    public static async Task<IResult> ResetScoreboard(ISender sender)
    {
        var command = new ResetScoreboardCommand();
        var result = await sender.Send(command);

        return Results.Ok();
    }

    public static async Task<IResult> GetTenMostRecent(ISender sender)
    {
        var query = new GetMostRecentQuery(10);
        var result = await sender.Send(query);

        return Results.Ok(result.Value);
    }
}
