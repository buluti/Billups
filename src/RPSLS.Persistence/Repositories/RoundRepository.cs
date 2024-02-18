using Microsoft.EntityFrameworkCore;
using RPSLS.Domain.Entities;
using RPSLS.Domain.Interfaces;

namespace RPSLS.Persistence.Repositories;

internal sealed class RoundRepository : Repository<Round>, IRoundRepository
{
    public RoundRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public void ClearScoreboardAsync()
    {
        _dbContext.Rounds.Clear();
    }

    public async Task<List<Round>> GetLatestResultsAsync(int resultsToShow)
    {
        return await _dbContext.Rounds.OrderByDescending(t => t.CreatedAtUtc).Take(resultsToShow).ToListAsync();
    }
}