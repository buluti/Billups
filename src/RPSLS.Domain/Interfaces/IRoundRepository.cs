using RPSLS.Domain.Entities;

namespace RPSLS.Domain.Interfaces
{
    public interface IRoundRepository
    {
        void Add(Round round);

        Task<List<Round>> GetLatestResultsAsync(int resultsToShow);

        void ClearScoreboardAsync();
    }
}
