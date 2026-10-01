using Xunit;
using Bogus;
using Poc.SDD.Application.Clients;
using Poc.SDD.Application.Projects;
using Poc.SDD.Application.Sectors;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;
using Moq;
using Poc.SDD.Application.Clients.Queries;
using Poc.SDD.Application.Projects.Queries;
using Poc.SDD.Application.Sectors.Queries;
using Poc.SDD.Application.Clients;
using Poc.SDD.Application.Projects;
using Poc.SDD.Application.Sectors;
using Moq;

namespace Poc.SDD.Application.IntegrationTests;

public class ClientCommandHandlerIntegrationTests
{
    private readonly Faker<CreateClientCommand> _createClientCommandFaker;
    private readonly Mock<IClientRepository> _mockClientRepository;
    private readonly CreateClientHandler _createClientHandler;

    public ClientCommandHandlerIntegrationTests()
    {
        _createClientCommandFaker = new Faker<CreateClientCommand>()
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber());

        _mockClientRepository = new Mock<IClientRepository>();
    }

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
        var result = await new CreateClientHandler().Handle(command, CancellationToken.None);

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
        var result = await new CreateClientHandler().Handle(command, CancellationToken.None);

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
        var result = await new CreateClientHandler().Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Email is required", result.Errors);
    }
}

public class ProjectCommandHandlerIntegrationTests
{
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
        var result = await new CreateProjectHandler().Handle(command, CancellationToken.None);

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
        var result = await new CreateProjectHandler().Handle(command, CancellationToken.None);

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
        var result = await new CreateProjectHandler().Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
    }
}

public class SectorCommandHandlerIntegrationTests
{
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
        var result = await new AssignSectorToClientHandler().Handle(command, CancellationToken.None);

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
        var result = await new AssignSectorToClientHandler().Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Client ID is required", result.Errors);
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
        var result = await new AssignSectorToProjectHandler().Handle(command, CancellationToken.None);

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
        var result = await new AssignSectorToProjectHandler().Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Project ID is required", result.Errors);
    }
}

public class QueryHandlerIntegrationTests
{
    [Fact]
    public async Task GetClientByIdHandler_WithValidId_ShouldReturnSuccess()
    {
        // Arrange
        var query = new GetClientByIdQuery { Id = Guid.NewGuid() };

        // Act
        var result = await new GetClientByIdHandler().Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetClientByIdHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var query = new GetClientByIdQuery { Id = Guid.Empty };

        // Act
        var result = await new GetClientByIdHandler().Handle(query, CancellationToken.None);

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
        var result = await new ListClientsHandler().Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetProjectByIdHandler_WithValidId_ShouldReturnSuccess()
    {
        // Arrange
        var query = new GetProjectByIdQuery { Id = Guid.NewGuid() };

        // Act
        var result = await new GetProjectByIdHandler().Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetProjectByIdHandler_WithEmptyId_ShouldReturnFailure()
    {
        // Arrange
        var query = new GetProjectByIdQuery { Id = Guid.Empty };

        // Act
        var result = await new GetProjectByIdHandler().Handle(query, CancellationToken.None);

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
        var result = await new ListProjectsHandler().Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ListSectorsHandler_ShouldReturnSuccess()
    {
        // Arrange
        var query = new ListSectorsQuery();

        // Act
        var result = await new ListSectorsHandler().Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
    }
}