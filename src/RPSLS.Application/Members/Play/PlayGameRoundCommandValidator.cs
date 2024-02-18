using FluentValidation;
using RPSLS.Domain.Entities.Enums;

namespace RPSLS.Application.Members.Play;

internal class PlayGameRoundCommandValidator : AbstractValidator<PlayGameRoundCommand>
{
    public PlayGameRoundCommandValidator()
    {
        RuleFor(x => x.PlayerChoice)
            .NotNull()
            .WithMessage("Choice_id is required")
            .GreaterThan(0)
            .WithMessage("Choice_id must be greater than 0. Accepted values are int[1-5]")
            .LessThanOrEqualTo(Enum.GetValues(typeof(RPSLSEnum)).Cast<int>().Max())
            .WithMessage("Choice_id must be less than 6. Accepted values are int[1-5]");
    }
}
