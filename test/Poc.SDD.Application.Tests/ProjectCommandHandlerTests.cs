using Xunit;
using Poc.SDD.Application.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Tests;

public class ProjectCommandHandlerTests
{
    private readonly CreateProjectHandler _createHandler = new();
    private readonly UpdateProjectHandler _updateHandler = new();

    [Fact]
    public async Task CreateProjectHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new CreateProjectCommand
        {
            Name = "Test Project",
            Description = "Test Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task CreateProjectHandler_WithEmptyName_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateProjectCommand
        {
            Name = "",
            Description = "Test Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project name is required", result.Errors);
    }

    [Fact]
    public async Task CreateProjectHandler_WithEmptyClientId_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateProjectCommand
        {
            Name = "Test Project",
            Description = "Test Description",
            ClientId = Guid.Empty
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
    }

    [Fact]
    public async Task CreateProjectHandler_WithWhitespaceName_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateProjectCommand
        {
            Name = "   ",
            Description = "Test Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project name is required", result.Errors);
    }

    [Fact]
    public async Task UpdateProjectHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new UpdateProjectCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Project",
            Description = "Updated Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task UpdateProjectHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var command = new UpdateProjectCommand
        {
            Id = Guid.Empty,
            Name = "Updated Project",
            Description = "Updated Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project ID is required", result.Errors);
    }

    [Fact]
    public async Task UpdateProjectHandler_WithEmptyName_ShouldReturnFailure()
    {
        // Arrange
        var command = new UpdateProjectCommand
        {
            Id = Guid.NewGuid(),
            Name = "",
            Description = "Updated Description",
            ClientId = Guid.NewGuid()
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project name is required", result.Errors);
    }
}