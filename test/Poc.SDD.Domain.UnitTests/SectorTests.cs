using Xunit;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Domain.Tests;

public class SectorTests
{
    [Fact]
    public void CreateSector_WithValidData_ShouldCreateSector()
    {
        // Arrange
        var sectorId = new SectorId(Guid.NewGuid());
        var name = new SectorName("Test Sector");
        var description = new SectorDescription("Test Description");

        // Act
        var sector = new Sector(sectorId, name, description);

        // Assert
        Assert.NotNull(sector);
        Assert.Equal(sectorId, sector.Id);
        Assert.Equal(name, sector.Name);
        Assert.Equal(description, sector.Description);
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
            new SectorId(Guid.NewGuid()),
            new SectorName("Test"),
            new SectorDescription("Test Description")
        );
        var clientId = new ClientId(Guid.NewGuid());

        // Act
        sector.AddClient(clientId);

        // Assert
        Assert.Contains(clientId, sector.Clients);
        Assert.NotNull(sector.UpdatedAt);
    }

    [Fact]
    public void RemoveClient_ShouldRemoveFromClientsCollection()
    {
        // Arrange
        var sector = new Sector(
            new SectorId(Guid.NewGuid()),
            new SectorName("Test"),
            new SectorDescription("Test Description")
        );
        var clientId = new ClientId(Guid.NewGuid());
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
            new SectorId(Guid.NewGuid()),
            new SectorName("Test"),
            new SectorDescription("Test Description")
        );
        var projectId = new ProjectId(Guid.NewGuid());

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
            new SectorId(Guid.NewGuid()),
            new SectorName("Test"),
            new SectorDescription("Test Description")
        );
        var projectId = new ProjectId(Guid.NewGuid());
        sector.AddProject(projectId);

        // Act
        sector.RemoveProject(projectId);

        // Assert
        Assert.DoesNotContain(projectId, sector.Projects);
    }
}