using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RPSLS.Application.Members.Choice;
using RPSLS.Application.Members.Play;
using RPSLS.Application.Members.Play.DTO;
using RPSLS.Presentation.Contracts;

namespace RPSLS.Presentation.Endpoints;

public static class GameEndpoint
{
    public static void AddGameModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/choices", GetChoices);
        app.MapGet("/choice", GetRandomChoice);
        app.MapPost("/play", PlayGameRound);
    }

    private static async Task<IResult> PlayGameRound(
        PlayRoundRequest request,
        IValidator<PlayGameRoundCommand> validator,
        ISender sender)
    {
        var command = new PlayGameRoundCommand(request.Player);

        var validationresult = validator.Validate(command);

        if (!validationresult.IsValid)
        {
            return Results.ValidationProblem(validationresult.ToDictionary());
        }

        var result = await sender.Send(command);

        var playGameResponse = new PlayGameRoundResponse(
            result.Value.Result.ToString().ToLower(),
            (int)result.Value.Player,
            (int)result.Value.Computer);

        return Results.Ok(playGameResponse);
    }

    public static async Task<IResult> GetChoices(ISender sender)
    {
        var query = new GetAllChoicesQuery();
        var result = await sender.Send(query);

        return result.IsSuccess ? Results.Ok(result.Value.Choices) : Results.BadRequest(result.Error);
    }

    public static async Task<IResult> GetRandomChoice(
        ISender sender)
    {
        var query = new GetSingleRandomChoiceQuery();
        var result = await sender.Send(query);

        return Results.Ok(result.Value);
    }
}
