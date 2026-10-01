using Xunit;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Domain.Tests;

public class ProjectTests
{
    [Fact]
    public void CreateProject_WithValidData_ShouldCreateProject()
    {
        // Arrange
        var projectId = new ProjectId(Guid.NewGuid());
        var name = new ProjectName("Test Project");
        var description = new ProjectDescription("Test Description");
        var clientId = new ClientId(Guid.NewGuid());

        // Act
        var project = new Project(projectId, name, description, clientId);

        // Assert
        Assert.NotNull(project);
        Assert.Equal(projectId, project.Id);
        Assert.Equal(name, project.Name);
        Assert.Equal(description, project.Description);
        Assert.Equal(clientId, project.ClientId);
        Assert.NotEqual(default, project.CreatedAt);
        Assert.Null(project.UpdatedAt);
        Assert.Empty(project.Sectors);
    }

    [Fact]
    public void UpdateProject_WithValidData_ShouldUpdate()
    {
        // Arrange
        var project = new Project(
            new ProjectId(Guid.NewGuid()),
            new ProjectName("Original"),
            new ProjectDescription("Original Description"),
            new ClientId(Guid.NewGuid())
        );

        var newName = new ProjectName("Updated");
        var newDescription = new ProjectDescription("Updated Description");

        // Act
        project.Update(newName, newDescription);

        // Assert
        Assert.Equal(newName, project.Name);
        Assert.Equal(newDescription, project.Description);
        Assert.NotNull(project.UpdatedAt);
    }

    [Fact]
    public void AddSector_ShouldAddToSectorsCollection()
    {
        // Arrange
        var project = new Project(
            new ProjectId(Guid.NewGuid()),
            new ProjectName("Test"),
            new ProjectDescription("Test Description"),
            new ClientId(Guid.NewGuid())
        );
        var sectorId = new SectorId(Guid.NewGuid());

        // Act
        project.Sectors.Add(sectorId);

        // Assert
        Assert.Contains(sectorId, project.Sectors);
    }

    [Fact]
    public void RemoveSector_ShouldRemoveFromSectorsCollection()
    {
        // Arrange
        var project = new Project(
            new ProjectId(Guid.NewGuid()),
            new ProjectName("Test"),
            new ProjectDescription("Test Description"),
            new ClientId(Guid.NewGuid())
        );
        var sectorId = new SectorId(Guid.NewGuid());
        project.Sectors.Add(sectorId);

        // Act
        project.Sectors.Remove(sectorId);

        // Assert
        Assert.DoesNotContain(sectorId, project.Sectors);
    }
}