using RPSLS.Domain.Entities.Enums;

namespace RPSLS.Domain.Interfaces
{
    public interface IRandomGameChoice
    {
        public Task<RPSLSEnum> Generate();
    }
}
