using Xunit;
using Poc.SDD.Application.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Tests;

public class SectorCommandHandlerTests
{
    private readonly AssignSectorToClientHandler _assignToClientHandler = new();
    private readonly AssignSectorToProjectHandler _assignToProjectHandler = new();

    [Fact]
    public async Task AssignSectorToClientHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new AssignSectorToClientCommand
        {
            ClientId = Guid.NewGuid(),
            SectorId = Guid.NewGuid()
        };

        // Act
        var result = await _assignToClientHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task AssignSectorToClientHandler_WithEmptyClientId_ShouldReturnFailure()
    {
        // Arrange
        var command = new AssignSectorToClientCommand
        {
            ClientId = Guid.Empty,
            SectorId = Guid.NewGuid()
        };

        // Act
        var result = await _assignToClientHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
    }

    [Fact]
    public async Task AssignSectorToClientHandler_WithEmptySectorId_ShouldReturnFailure()
    {
        // Arrange
        var command = new AssignSectorToClientCommand
        {
            ClientId = Guid.NewGuid(),
            SectorId = Guid.Empty
        };

        // Act
        var result = await _assignToClientHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Sector ID is required", result.Errors);
    }

    [Fact]
    public async Task AssignSectorToProjectHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new AssignSectorToProjectCommand
        {
            ProjectId = Guid.NewGuid(),
            SectorId = Guid.NewGuid()
        };

        // Act
        var result = await _assignToProjectHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task AssignSectorToProjectHandler_WithEmptyProjectId_ShouldReturnFailure()
    {
        // Arrange
        var command = new AssignSectorToProjectCommand
        {
            ProjectId = Guid.Empty,
            SectorId = Guid.NewGuid()
        };

        // Act
        var result = await _assignToProjectHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project ID is required", result.Errors);
    }

    [Fact]
    public async Task AssignSectorToProjectHandler_WithEmptySectorId_ShouldReturnFailure()
    {
        // Arrange
        var command = new AssignSectorToProjectCommand
        {
            ProjectId = Guid.NewGuid(),
            SectorId = Guid.Empty
        };

        // Act
        var result = await _assignToProjectHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Sector ID is required", result.Errors);
    }
}