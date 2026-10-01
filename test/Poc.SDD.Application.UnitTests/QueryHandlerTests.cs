using Xunit;
using Poc.SDD.Application.Clients.Queries;
using Poc.SDD.Application.Projects.Queries;
using Poc.SDD.Application.Sectors.Queries;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Tests;

public class QueryHandlerTests
{
    private readonly GetClientByIdHandler _getClientByIdHandler = new();
    private readonly ListClientsHandler _listClientsHandler = new();
    private readonly GetProjectByIdHandler _getProjectByIdHandler = new();
    private readonly ListProjectsHandler _listProjectsHandler = new();
    private readonly ListSectorsHandler _listSectorsHandler = new();

    [Fact]
    public async Task GetClientByIdHandler_WithValidId_ShouldReturnSuccess()
    {
        // Arrange
        var query = new GetClientByIdQuery { Id = Guid.NewGuid() };

        // Act
        var result = await _getClientByIdHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetClientByIdHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var query = new GetClientByIdQuery { Id = Guid.Empty };

        // Act
        var result = await _getClientByIdHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
    }

    [Fact]
    public async Task ListClientsHandler_ShouldReturnSuccess()
    {
        // Arrange
        var query = new ListClientsQuery();

        // Act
        var result = await _listClientsHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetProjectByIdHandler_WithValidId_ShouldReturnSuccess()
    {
        // Arrange
        var query = new GetProjectByIdQuery { Id = Guid.NewGuid() };

        // Act
        var result = await _getProjectByIdHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetProjectByIdHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var query = new GetProjectByIdQuery { Id = Guid.Empty };

        // Act
        var result = await _getProjectByIdHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project ID is required", result.Errors);
    }

    [Fact]
    public async Task ListProjectsHandler_ShouldReturnSuccess()
    {
        // Arrange
        var query = new ListProjectsQuery();

        // Act
        var result = await _listProjectsHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ListSectorsHandler_ShouldReturnSuccess()
    {
        // Arrange
        var query = new ListSectorsQuery();

        // Act
        var result = await _listSectorsHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }
}