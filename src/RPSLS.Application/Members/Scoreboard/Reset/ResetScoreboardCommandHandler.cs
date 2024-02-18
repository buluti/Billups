using RPSLS.Application.Abstractions;
using RPSLS.Domain.Interfaces;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Scoreboard.Reset;

internal sealed class ResetScoreboardCommandHandler : ICommandHandler<ResetScoreboardCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoundRepository _roundRepository;

    public ResetScoreboardCommandHandler(
        IUnitOfWork unitOfWork,
        IRoundRepository roundRepository)
    {
        _unitOfWork = unitOfWork;
        _roundRepository = roundRepository;
    }

    public async Task<Result> Handle(
        ResetScoreboardCommand request,
        CancellationToken cancellationToken)
    {
        _roundRepository.ClearScoreboardAsync();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
