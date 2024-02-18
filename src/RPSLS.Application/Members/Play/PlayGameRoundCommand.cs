using RPSLS.Application.Abstractions;
using RPSLS.Domain.Entities;

namespace RPSLS.Application.Members.Play;

public sealed record PlayGameRoundCommand(
    int PlayerChoice)
    : ICommand<Round>;

