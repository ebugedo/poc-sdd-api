using Xunit;
using Bogus;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Domain.IntegrationTests;

public class ClientEntityTests
{
    private readonly Faker<Client> _clientFaker;

    public ClientEntityTests()
    {
        _clientFaker = new Faker<Client>()
            .CustomInstantiator(f => new Client(
                ClientId.CreateUnique(),
                new ClientName(f.Person.FullName),
                new ClientEmail(f.Internet.Email()),
                new ClientPhone(f.Phone.PhoneNumber())))
            .RuleFor(c => c.CreatedAt, f => f.Date.Past());
    }

    [Fact]
    public void CreateClient_WithValidData_ShouldCreateClient()
    {
        // Arrange & Act
        var client = _clientFaker.Generate();

        // Assert
        Assert.NotNull(client);
        Assert.NotEqual(Guid.Empty, client.Id.Value);
        Assert.NotNull(client.Name);
        Assert.NotNull(client.Email);
        Assert.NotNull(client.Phone);
        Assert.NotEqual(default, client.CreatedAt);
        Assert.Null(client.UpdatedAt);
        Assert.Empty(client.Sectors);
    }

    [Fact]
    public void UpdateClient_WithValidData_ShouldUpdateClient()
    {
        // Arrange
        var client = _clientFaker.Generate();

        // Act
        client.Update(
            new ClientName("Updated Name"),
            new ClientEmail("updated@example.com"),
            new ClientPhone("999999999"));

        // Assert
        Assert.Equal("Updated Name", client.Name.Value);
        Assert.Equal("updated@example.com", client.Email.Value);
        Assert.Equal("999999999", client.Phone.Value);
        Assert.NotNull(client.UpdatedAt);
    }

    [Fact]
    public void AddSector_ShouldAddToSectorsCollection()
    {
        // Arrange
        var client = _clientFaker.Generate();
        var sectorId = SectorId.CreateUnique();

        // Act
        client.Sectors.Add(sectorId);

        // Assert
        Assert.Contains(sectorId, client.Sectors);
    }

    [Fact]
    public void RemoveSector_ShouldRemoveFromSectorsCollection()
    {
        // Arrange
        var client = _clientFaker.Generate();
        var sectorId = SectorId.CreateUnique();
        client.Sectors.Add(sectorId);

        // Act
        client.Sectors.Remove(sectorId);

        // Assert
        Assert.DoesNotContain(sectorId, client.Sectors);
    }
}

public class ProjectEntityTests
{
    private readonly Faker<Project> _projectFaker;

    public ProjectEntityTests()
    {
        _projectFaker = new Faker<Project>()
            .CustomInstantiator(f => new Project(
                ProjectId.CreateUnique(),
                new ProjectName(f.Commerce.ProductName()),
                new ProjectDescription(f.Lorem.Sentence()),
                ClientId.CreateUnique()))
            .RuleFor(p => p.CreatedAt, f => f.Date.Past());
    }

    [Fact]
    public void CreateProject_WithValidData_ShouldCreateProject()
    {
        // Arrange & Act
        var project = _projectFaker.Generate();

        // Assert
        Assert.NotNull(project);
        Assert.NotEqual(Guid.Empty, project.Id.Value);
        Assert.NotNull(project.Name);
        Assert.NotNull(project.Description);
        Assert.NotEqual(Guid.Empty, project.ClientId.Value);
        Assert.NotEqual(default, project.CreatedAt);
        Assert.Null(project.UpdatedAt);
        Assert.Empty(project.Sectors);
    }

[Fact]
    public void UpdateProject_WithValidData_ShouldUpdateProject()
    {
        // Arrange
        var project = _projectFaker.Generate();

        var newName = new ProjectName("Updated");
        var newDescription = new ProjectDescription("Updated Description");

        // Act
        project.Update(newName, newDescription);

        // Assert
        Assert.Equal("Updated", project.Name.Value);
        Assert.Equal("Updated Description", project.Description.Value);
        Assert.NotNull(project.UpdatedAt);
    }

    [Fact]
    public void AddSector_ShouldAddToSectorsCollection()
    {
        // Arrange
        var project = _projectFaker.Generate();
        var sectorId = SectorId.CreateUnique();

        // Act
        project.Sectors.Add(sectorId);

        // Assert
        Assert.Contains(sectorId, project.Sectors);
    }

    [Fact]
    public void RemoveSector_ShouldRemoveFromSectorsCollection()
    {
        // Arrange
        var project = _projectFaker.Generate();
        var sectorId = SectorId.CreateUnique();
        project.Sectors.Add(sectorId);

        // Act
        project.Sectors.Remove(sectorId);

        // Assert
        Assert.DoesNotContain(sectorId, project.Sectors);
    }
}

public class SectorEntityTests
{
    private readonly Faker<Sector> _sectorFaker;

    public SectorEntityTests()
    {
        _sectorFaker = new Faker<Sector>()
            .CustomInstantiator(f => new Sector(
                SectorId.CreateUnique(),
                new SectorName(f.Commerce.Categories(1)[0]),
                new SectorDescription(f.Lorem.Sentence())))
            .RuleFor(s => s.CreatedAt, f => f.Date.Past());
    }

    [Fact]
    public void CreateSector_WithValidData_ShouldCreateSector()
    {
        // Arrange & Act
        var sector = _sectorFaker.Generate();

        // Assert
        Assert.NotNull(sector);
        Assert.NotEqual(Guid.Empty, sector.Id.Value);
        Assert.NotNull(sector.Name);
        Assert.NotNull(sector.Description);
        Assert.NotEqual(default, sector.CreatedAt);
        Assert.Null(sector.UpdatedAt);
        Assert.Empty(sector.Clients);
        Assert.Empty(sector.Projects);
    }

    [Fact]
    public void AddClient_ShouldAddToClientsCollection()
    {
        // Arrange
        var sector = new Sector(
            SectorId.CreateUnique(),
            new SectorName("Test"),
            new SectorDescription("Test Description"));
        var clientId = ClientId.CreateUnique();

        // Act
        sector.AddClient(clientId);

        // Assert
        Assert.Contains(clientId, sector.Clients);
    }

    [Fact]
    public void RemoveClient_ShouldRemoveFromClientsCollection()
    {
        // Arrange
        var sector = new Sector(
            SectorId.CreateUnique(),
            new SectorName("Test"),
            new SectorDescription("Test Description"));
        var clientId = ClientId.CreateUnique();
        sector.AddClient(clientId);

        // Act
        sector.RemoveClient(clientId);

        // Assert
        Assert.DoesNotContain(clientId, sector.Clients);
    }

    [Fact]
    public void AddProject_ShouldAddToProjectsCollection()
    {
        // Arrange
        var sector = new Sector(
            SectorId.CreateUnique(),
            new SectorName("Test"),
            new SectorDescription("Test Description"));
        var projectId = ProjectId.CreateUnique();

        // Act
        sector.AddProject(projectId);

        // Assert
        Assert.Contains(projectId, sector.Projects);
    }

    [Fact]
    public void RemoveProject_ShouldRemoveFromProjectsCollection()
    {
        // Arrange
        var sector = new Sector(
            SectorId.CreateUnique(),
            new SectorName("Test"),
            new SectorDescription("Test Description"));
        var projectId = ProjectId.CreateUnique();
        sector.AddProject(projectId);

        // Act
        sector.RemoveProject(projectId);

        // Assert
        Assert.DoesNotContain(projectId, sector.Projects);
    }
}