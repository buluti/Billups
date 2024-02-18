using RPSLS.Application.Abstractions;
using RPSLS.Domain.Entities;
using RPSLS.Domain.Entities.Enums;
using RPSLS.Domain.Interfaces;
using RPSLS.Domain.Shared;

namespace RPSLS.Application.Members.Play
{
    public sealed class PlayGameRoundCommandHandler : ICommandHandler<PlayGameRoundCommand, Round>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRandomGameChoice _randomChoice;
        private readonly IRoundRepository _roundRepository;

        public PlayGameRoundCommandHandler(
            IUnitOfWork unitOfWork,
            IRandomGameChoice randomChoice,
            IRoundRepository roundRepository)
        {
            _unitOfWork = unitOfWork;
            _randomChoice = randomChoice;
            _roundRepository = roundRepository;
        }

        public async Task<Result<Round>> Handle(
            PlayGameRoundCommand request,
            CancellationToken cancellationToken)
        {
            RPSLSEnum playerChoice = (RPSLSEnum)request.PlayerChoice;
            RPSLSEnum computer = await _randomChoice.Generate();
            ResultEnum result = CompareChoices(playerChoice, computer);

            var round = new Round(result, playerChoice, computer);
            _roundRepository.Add(round);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return round;
        }

        private ResultEnum CompareChoices(RPSLSEnum player, RPSLSEnum computer)
        {
            ResultEnum result = ResultEnum.Tie;

            if (player == computer)
                return result;

            switch (player)
            {
                case RPSLSEnum.Rock:
                    {
                        if (computer == RPSLSEnum.Scissors || computer == RPSLSEnum.Lizard)
                            result = ResultEnum.Win;
                        result = ResultEnum.Loose;
                        break;
                    }
                case RPSLSEnum.Paper:
                    {
                        if (computer == RPSLSEnum.Rock || computer == RPSLSEnum.Spock)
                            result = ResultEnum.Win;
                        result = ResultEnum.Loose;
                        break;
                    }
                case RPSLSEnum.Scissors:
                    {
                        if (computer == RPSLSEnum.Paper || computer == RPSLSEnum.Lizard)
                            result = ResultEnum.Win;
                        result = ResultEnum.Loose;
                        break;
                    }
                case RPSLSEnum.Lizard:
                    {
                        if (computer == RPSLSEnum.Spock || computer == RPSLSEnum.Paper)
                            result = ResultEnum.Win;
                        result = ResultEnum.Loose;
                        break;
                    }
                case RPSLSEnum.Spock:
                    {
                        if (computer == RPSLSEnum.Rock || computer == RPSLSEnum.Scissors)
                            result = ResultEnum.Win;
                        result = ResultEnum.Loose;
                        break;
                    }
            }

            return result;
        }
    }
}
