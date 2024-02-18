using RPSLS.Domain.Entities.Enums;
using RPSLS.Domain.Interfaces;

namespace RPSLS.Infrastructure.Services
{
    internal class RandomGameChoice : IRandomGameChoice
    {
        private readonly BoohmaGetRandomNumberService _boohmaService;

        public RandomGameChoice(BoohmaGetRandomNumberService boohmaService)
        {
            _boohmaService = boohmaService;
        }

        public async Task<RPSLSEnum> Generate()
        {
            var randomInt = await _boohmaService.GetFromApiAsync();

            RPSLSEnum value = RPSLSEnum.Rock;
            if (randomInt > 81)
                value = RPSLSEnum.Spock;
            else if (randomInt > 61)
                value = RPSLSEnum.Lizard;
            else if (randomInt > 41)
                value = RPSLSEnum.Scissors;
            else if (randomInt > 21)
                value = RPSLSEnum.Paper;

            return value;
        }
    }
}
