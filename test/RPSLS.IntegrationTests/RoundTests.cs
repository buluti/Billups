using RPSLS.Application.Members.Play;
using Xunit;

namespace RPSLS.IntegrationTests;

public class RoundTests : BaseIntegrationTest
{
    public RoundTests(IntegrationTestsWebAppFactory factory)
    : base(factory)
    {

    }

    [Fact]
    public async Task PlayGameRound_ShouldAdd_NewRoundToDatabase()
    {
        // Arrange
        var command = new PlayGameRoundCommand(2);
        
        // Act
        //Task Action() = 
        var result =  await Sender.Send(command);

        // Asserty
        var round = DbContext.Rounds.FirstOrDefault(r => r.Id == result.Value.Id);

        Assert.NotNull(round);
    }
}
