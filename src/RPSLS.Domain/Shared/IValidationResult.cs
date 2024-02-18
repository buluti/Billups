namespace RPSLS.Domain.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "VaidationError",
        "Validation problem occured.");

    Error[] Errors { get; }
}
