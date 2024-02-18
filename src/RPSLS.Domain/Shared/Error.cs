namespace RPSLS.Domain.Shared;

/// <summary>
/// Represents a concrete domain error.
/// </summary>
public class Error
{
    public static readonly Error None = new Error(string.Empty, string.Empty);
    public static readonly Error NullValue = new Error("Error.NullValue", "The specified result value is null ");

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    public static implicit operator string(Error error) => error.Code;
}
