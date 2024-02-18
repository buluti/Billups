using RPSLS.Application.Abstractions;
using RPSLS.Application.Members.Choice.DTO;

namespace RPSLS.Application.Members.Choice;

public sealed record GetSingleRandomChoiceQuery : IQuery<GameChoiceResponse>;
