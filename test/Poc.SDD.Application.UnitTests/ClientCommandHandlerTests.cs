using Xunit;
using Poc.SDD.Application.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Tests;

public class ClientCommandHandlerTests
{
    private readonly CreateClientHandler _createHandler = new();
    private readonly UpdateClientHandler _updateHandler = new();

    [Fact]
    public async Task CreateClientHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new CreateClientCommand
        {
            Name = "Test Client",
            Email = "test@example.com",
            Phone = "123456789"
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task CreateClientHandler_WithEmptyName_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateClientCommand
        {
            Name = "",
            Email = "test@example.com",
            Phone = "123456789"
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Name is required", result.Errors);
    }

    [Fact]
    public async Task CreateClientHandler_WithEmptyEmail_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateClientCommand
        {
            Name = "Test Client",
            Email = "",
            Phone = "123456789"
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Email is required", result.Errors);
    }

    [Fact]
    public async Task CreateClientHandler_WithWhitespaceName_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateClientCommand
        {
            Name = "   ",
            Email = "test@example.com",
            Phone = "123456789"
        };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Name is required", result.Errors);
    }

    [Fact]
    public async Task UpdateClientHandler_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var command = new UpdateClientCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Client",
            Email = "updated@example.com",
            Phone = "987654321"
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task UpdateClientHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var command = new UpdateClientCommand
        {
            Id = Guid.Empty,
            Name = "Updated Client",
            Email = "updated@example.com",
            Phone = "987654321"
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
    }

    [Fact]
    public async Task UpdateClientHandler_WithEmptyName_ShouldReturnFailure()
    {
        // Arrange
        var command = new UpdateClientCommand
        {
            Id = Guid.NewGuid(),
            Name = "",
            Email = "updated@example.com",
            Phone = "987654321"
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Name is required", result.Errors);
    }

    [Fact]
    public async Task UpdateClientHandler_WithEmptyEmail_ShouldReturnFailure()
    {
        // Arrange
        var command = new UpdateClientCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Client",
            Email = "",
            Phone = "987654321"
        };

        // Act
        var result = await _updateHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Email is required", result.Errors);
    }
}