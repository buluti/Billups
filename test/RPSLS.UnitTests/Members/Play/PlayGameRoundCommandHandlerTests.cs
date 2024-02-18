using Moq;
using RPSLS.Application.Members.Play;
using RPSLS.Domain.Entities;
using RPSLS.Domain.Interfaces;
using RPSLS.Domain.Shared;
using Xunit;

namespace RPSLS.UnitTests.Members.Play;

public class PlayGameRoundCommandHandlerTests
{
    private readonly Mock<IRoundRepository> _roundRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRandomGameChoice> _randomGameChoiceMock;

    public PlayGameRoundCommandHandlerTests()
    {
        _randomGameChoiceMock = new();
        _unitOfWorkMock = new();
        _roundRepositoryMock = new();
    }

    [Fact]
    public async void Handle_Should_CallAddOnRepository()
    {
        // Arrange
        var command = new PlayGameRoundCommand(2);
        var handler = new PlayGameRoundCommandHandler(
            _unitOfWorkMock.Object,
            _randomGameChoiceMock.Object,
            _roundRepositoryMock.Object);

        // Act
        Result<Round> result = await handler.Handle(command, default);

        // Assert
        _roundRepositoryMock.Verify(
            x => x.Add(It.Is<Round>(m => m.Id == result.Value.Id)),
            Times.Once);
    }
}
