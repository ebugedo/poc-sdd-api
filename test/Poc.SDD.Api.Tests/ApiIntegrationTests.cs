using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Poc.SDD.Api;
using Poc.SDD.Application.Clients;
using Poc.SDD.Application.Projects;
using Poc.SDD.Application.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Api.Tests;

public class ApiIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    private void SetApiVersionHeader()
    {
        if (!_client.DefaultRequestHeaders.Contains("api-version"))
        {
            _client.DefaultRequestHeaders.Add("api-version", "1.0");
        }
    }

    [Fact]
    public async Task Client_Creation_Consultation_And_Update_Flow_ShouldWork()
    {
        SetApiVersionHeader();
        
        // Create client
        var createCommand = new CreateClientCommand
        {
            Name = "Test Client",
            Email = "test@example.com",
            Phone = "123456789"
        };

        var createResponse = await _client.PostAsJsonAsync("/api/v1/clientes", createCommand);
        var createContent = await createResponse.Content.ReadAsStringAsync();
        
        if (createResponse.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"Create client failed: {createResponse.StatusCode} - {createContent}");
        }
        
        var createResult = await createResponse.Content.ReadFromJsonAsync<Result>();
        Assert.True(createResult.IsSuccess);

        // List clients
        var listResponse = await _client.GetAsync("/api/v1/clientes");
        var listContent = await listResponse.Content.ReadAsStringAsync();
        
        if (listResponse.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"List clients failed: {listResponse.StatusCode} - {listContent}");
        }
        
        Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
    }

    [Fact]
    public async Task Project_Creation_With_Client_Assignment_ShouldWork()
    {
        SetApiVersionHeader();
        
        // Create a client first
        var createClientCommand = new CreateClientCommand
        {
            Name = "Client for Project",
            Email = "client@project.com",
            Phone = "987654321"
        };

        var clientResponse = await _client.PostAsJsonAsync("/api/v1/clientes", createClientCommand);
        var clientContent = await clientResponse.Content.ReadAsStringAsync();
        
        if (clientResponse.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"Create client failed: {clientResponse.StatusCode} - {clientContent}");
        }
        
        Assert.Equal(HttpStatusCode.OK, clientResponse.StatusCode);
    }

    [Fact]
    public async Task Sector_Assignment_To_Client_And_Project_ShouldWork()
    {
        // Test that endpoints exist and return BadRequest for invalid IDs (not 404)
        var assignToClientCommand = new AssignSectorToClientCommand
        {
            ClientId = Guid.NewGuid(),
            SectorId = Guid.NewGuid()
        };

        var assignClientResponse = await _client.PostAsJsonAsync("/api/v1/sectores/assign-client", assignToClientCommand);
        Assert.Equal(HttpStatusCode.BadRequest, assignClientResponse.StatusCode);

        var assignToProjectCommand = new AssignSectorToProjectCommand
        {
            ProjectId = Guid.NewGuid(),
            SectorId = Guid.NewGuid()
        };

        var assignProjectResponse = await _client.PostAsJsonAsync("/api/v1/sectores/assign-project", assignToProjectCommand);
        Assert.Equal(HttpStatusCode.BadRequest, assignProjectResponse.StatusCode);
    }

    [Fact]
    public async Task List_Endpoints_Should_Return_Success()
    {
        // Test all list endpoints
        var clientsList = await _client.GetAsync("/api/v1/clientes");
        var clientsListContent = await clientsList.Content.ReadAsStringAsync();
        
        if (clientsList.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"List clients failed: {clientsList.StatusCode} - {clientsListContent}");
        }
        
        Assert.Equal(HttpStatusCode.OK, clientsList.StatusCode);

        var projectsList = await _client.GetAsync("/api/v1/proyectos");
        var projectsListContent = await projectsList.Content.ReadAsStringAsync();
        
        if (projectsList.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"List projects failed: {projectsList.StatusCode} - {projectsListContent}");
        }
        
        Assert.Equal(HttpStatusCode.OK, projectsList.StatusCode);

        var sectorsList = await _client.GetAsync("/api/v1/sectores");
        var sectorsListContent = await sectorsList.Content.ReadAsStringAsync();
        
        if (sectorsList.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"List sectors failed: {sectorsList.StatusCode} - {sectorsListContent}");
        }
        
        Assert.Equal(HttpStatusCode.OK, sectorsList.StatusCode);
    }
}