using MediatR;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TRespone>
    : IRequestHandler<TCommand, Result<TRespone>>
    where TCommand : ICommand<TRespone>
{
}