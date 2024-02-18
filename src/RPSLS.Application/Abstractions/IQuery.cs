using MediatR;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Abstractions;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}