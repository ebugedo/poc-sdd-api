using Xunit;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Domain.Tests;

public class ClientTests
{
    [Fact]
    public void CreateClient_WithValidData_ShouldCreateClient()
    {
        // Arrange
        var clientId = ClientId.CreateUnique();
        var name = new ClientName("Test Client");
        var email = new ClientEmail("test@example.com");
        var phone = new ClientPhone("123456789");

        // Act
        var client = new Client(clientId, name, email, phone);

        // Assert
        Assert.NotNull(client);
        Assert.Equal(clientId, client.Id);
        Assert.Equal(name, client.Name);
        Assert.Equal(email, client.Email);
        Assert.Equal(phone, client.Phone);
        Assert.NotEqual(default, client.CreatedAt);
        Assert.Null(client.UpdatedAt);
        Assert.Empty(client.Sectors);
    }

    [Fact]
    public void UpdateClient_WithValidData_ShouldUpdate()
    {
        // Arrange
        var client = new Client(
            ClientId.CreateUnique(),
            new ClientName("Original"),
            new ClientEmail("original@example.com"),
            new ClientPhone("111111111")
        );

        var newName = new ClientName("Updated");
        var newEmail = new ClientEmail("updated@example.com");
        var newPhone = new ClientPhone("999999999");

        // Act
        client.Update(newName, newEmail, newPhone);

        // Assert
        Assert.Equal(newName, client.Name);
        Assert.Equal(newEmail, client.Email);
        Assert.Equal(newPhone, client.Phone);
        Assert.NotNull(client.UpdatedAt);
    }

    [Fact]
    public void AddSector_ShouldAddToSectorsCollection()
    {
        // Arrange
        var client = new Client(
            ClientId.CreateUnique(),
            new ClientName("Test"),
            new ClientEmail("test@example.com"),
            new ClientPhone("123456789")
        );
        var sectorId = new SectorId(Guid.NewGuid());

        // Act
        client.Sectors.Add(sectorId);

        // Assert
        Assert.Contains(sectorId, client.Sectors);
    }

    [Fact]
    public void RemoveSector_ShouldRemoveFromSectorsCollection()
    {
        // Arrange
        var client = new Client(
            ClientId.CreateUnique(),
            new ClientName("Test"),
            new ClientEmail("test@example.com"),
            new ClientPhone("123456789")
        );
        var sectorId = new SectorId(Guid.NewGuid());
        client.Sectors.Add(sectorId);

        // Act
        client.Sectors.Remove(sectorId);

        // Assert
        Assert.DoesNotContain(sectorId, client.Sectors);
    }
}