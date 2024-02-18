using RPSLS.Domain.Entities.Enums;

namespace RPSLS.Domain.Interfaces
{
    public interface IPlayGameRound
    {
        public Task<RPSLSEnum> GetRandomNumberFromApiAsync();
    }
}
