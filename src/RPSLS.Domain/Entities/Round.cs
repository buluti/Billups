using RPSLS.Domain.Abstractions;
using RPSLS.Domain.Entities.Enums;

namespace RPSLS.Domain.Entities;

public class Round : Entity
{
    public Round()
    {

    }
    public Round(int result, int player, int computer)
    {
        Result = (ResultEnum)result;
        Player = (RPSLSEnum)player;
        Computer = (RPSLSEnum)computer;
    }

    public Round(ResultEnum result, RPSLSEnum playerChoice, RPSLSEnum computer)
    {
        Result = result;
        Player = playerChoice;
        Computer = computer;
    }

    public ResultEnum Result { get; set; }
    public RPSLSEnum Player { get; set; }
    public RPSLSEnum Computer { get; set; }
}
