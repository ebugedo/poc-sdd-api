# Tasks

## 1. Domain Layer

- [x] 1.1 Create Client aggregate, entity, and value objects
- [x] 1.2 Create Project aggregate, entity, and value objects
- [x] 1.3 Create Sector aggregate, entity, and value objects
- [x] 1.4 Implement Many-to-Many relationship configurations for Client-Project and Project-Sector

## 2. Application Layer - Commands

- [x] 2.1 Create CreateClient command and handler
- [x] 2.2 Create UpdateClient command and handler
- [x] 2.3 Create CreateProject command and handler
- [x] 2.4 Create UpdateProject command and handler
- [x] 2.5 Create AssignSectorToClient command and handler
- [x] 2.6 Create AssignSectorToProject command and handler

## 3. Application Layer - Queries

- [x] 3.1 Create GetClientById query and handler
- [x] 3.2 Create GetProjectById query and handler
- [x] 3.3 Create ListClients query and handler
- [x] 3.4 Create ListProjects query and handler
- [x] 3.5 Create ListSectors query and handler

## 4. Infrastructure Layer

- [x] 4.1 Implement Client repository using Entity Framework Core
- [x] 4.2 Implement Project repository using Entity Framework Core
- [x] 4.3 Implement Sector repository using Entity Framework Core
- [x] 4.4 Configure DbContext with Many-to-Many relationship mappings
- [x] 4.5 Implement AutoMapper profiles for Domain ↔ DTO mapping

## 5. API Layer

- [x] 5.1 Create ClientsController with CRUD endpoints (GET/POST/PUT/DELETE /api/v1/clientes)
- [x] 5.2 Create ProjectsController with CRUD endpoints (GET/POST/PUT/DELETE /api/v1/proyectos)
- [x] 5.3 Create SectorsController with CRUD and assignment endpoints (GET/POST /api/v1/sectores)
- [x] 5.4 Implement API versioning with v1 in URL

## 6. Dependency Injection

- [x] 6.1 Register services with Autofac
- [x] 6.2 Register MediatR
- [x] 6.3 Configure EF Core DbContext

## 7. Unit Testing

- [x] 7.1 Create Client unit tests with xUnit, Moq, and Bogus
- [x] 7.2 Create Project unit tests with xUnit, Moq, and Bogus
- [x] 7.3 Create Sector unit tests with xUnit, Moq, and Bogus
- [x] 7.4 Create command handler tests for all CRUD operations with xUnit, Moq, and Bogus
- [x] 7.5 Create query handler tests for all queries with xUnit, Moq, and Bogus

## 8. Integration Tests

- [x] 8.1 Implement integration test suite for API endpoints with xUnit, Moq, and Bogus
- [x] 8.2 Test client creation, consultation, and update flow with xUnit, Moq, and Bogus
- [x] 8.3 Test project creation with client assignment with xUnit, Moq, and Bogus
- [x] 8.4 Test sector assignment to clients and projects with xUnit, Moq, and Bogus

## 9. Documentation

- [x] 9.1 Update API documentation with new endpoints
- [x] 9.2 Document domain models and relationships
- [x] 9.3 Create setup guide for DDD architecture

## 10. Final Verification

- [x] 10.1 Run all unit tests and verify pass
- [x] 10.2 Run integration tests and verify flows
- [x] 10.3 Build solution and verify no compilation errors

## 11. Test Project Reorganization (New Convention)

- [x] 12.1 **Rename existing test projects to follow new naming convention**:
  - [x] 12.1.1 Rename `Poc.SDD.Domain.Tests` → `Poc.SDD.Domain.UnitTests`
  - [x] 12.1.2 Rename `Poc.SDD.Application.Tests` → `Poc.SDD.Application.UnitTests`
  - [x] 12.1.3 Rename `Poc.SDD.Api.Tests` → `Poc.SDD.Api.IntegrationTests`

- [x] 12.2 **Create missing integration test projects** (per new convention: every code project must have an integration test project):
  - [x] 12.2.1 Create `Poc.SDD.Domain.IntegrationTests` project
  - [x] 12.2.2 Create `Poc.SDD.Application.IntegrationTests` project
  - [x] 12.2.3 Ensure `Poc.SDD.Api.IntegrationTests` (renamed from Api.Tests) has proper integration test structure

- [x] 12.3 **Update project references and imports**:
  - [x] 12.3.1 Fix project references in renamed test projects
  - [x] 12.3.2 Fix import/require paths across all files in `test/`
  - [x] 12.3.3 Update test runner configuration to discover tests in `.UnitTests` and `.IntegrationTests` projects
  - [x] 12.3.4 Update solution file (.slnx) with renamed and new test projects

- [x] 12.4 **Implement integration tests for Domain and Application layers**:
  - [x] 12.4.1 Add integration tests for Domain layer (entities, value objects, aggregates)
  - [x] 12.4.2 Add integration tests for Application layer (command/query handlers with real dependencies)
  - [x] 12.4.3 Ensure integration tests use Bogus for test data generation

- [x] 12.5 **Verify all tests pass**:
  - [x] 12.5.1 Run all unit tests and verify pass (should be 41 tests)
  - [x] 12.5.2 Run all integration tests and verify pass
  - [x] 12.5.3 Build solution and verify no compilation errors

## Remediation & Validation Fixes

### Critical Fixes (Must Fix First)

- [x] **R1.1** Create `CreateSectorCommand` and `CreateSectorHandler` for sector creation
  - **Reason**: Spec requires "Sector can be created" but no command/handler exists
  - **Files**: Create `src/Poc.SDD.Application/Sectors/CreateSectorCommand.cs`, `CreateSectorHandler.cs`
  - **Validation**: POST `/api/v1/sectores` endpoint works

- [x] **R1.2** Create `CreateSectorHandler` with proper validation
  - **Reason**: Need handler to process sector creation command
  - **Files**: `src/Poc.SDD.Application/Sectors/CreateSectorHandler.cs`

- [x] **R1.3** Add POST `/api/v1/sectores` endpoint in `SectorsController`
  - **Reason**: Spec requires "Sector can be created" endpoint
  - **Files**: Update `src/Poc.SDD.Api/Controllers/V1/SectorsController.cs`

- [x] **R1.4** Fix `SectorsController.GetById` to return actual sector data
  - **Reason**: Currently returns `Result.Success()` instead of actual sector data
  - **Files**: `src/Poc.SDD.Api/Controllers/V1/SectorsController.cs`

### API Versioning Fixes (Critical - Tests Failing)

- [x] **R2.1** Add `api-version` header to test client in `CustomWebApplicationFactory`
  - **Reason**: 3/4 API integration tests fail with "ApiVersionUnspecified"
  - **Files**: `test/Poc.SDD.Api.IntegrationTests/CustomWebApplicationFactory.cs`
  - **Action**: Add `client.DefaultRequestHeaders.Add("api-version", "1.0")` in `CreateClient` method

- [x] **R2.2** Ensure API versioning is properly configured in test environment
  - **Reason**: Tests fail with "ApiVersionUnspecified" error
  - **Files**: `test/Poc.SDD.Api.IntegrationTests/CustomWebApplicationFactory.cs`, `src/Poc.SDD.Api/Program.cs`

### Critical Infrastructure Fixes

- [x] **R3.1** Fix `Poc.SDD.Domain.IntegrationTests` project configuration
  - **Reason**: Build error "Solution root could not be located"
  - **Files**: `test/Poc.SDD.Domain.IntegrationTests/Poc.SDD.Domain.IntegrationTests.csproj`
  - **Action**: Add proper `<SolutionRoot>` or configure `WebApplicationFactory` correctly

- [x] **R3.2** Fix `Poc.SDD.Domain.IntegrationTests` project reference to Infrastructure
  - **Reason**: Needs reference to Infrastructure for EF Core InMemory database
  - **Files**: `test/Poc.SDD.Domain.IntegrationTests/Poc.SDD.Domain.IntegrationTests.csproj`

### Documentation & Typos Fixes

- [x] **R4.1** Fix "Blogus" typo to "Bogus" in design.md
  - **Reason**: Design.md says "Blogus" but Bogus is actually used
  - **Files**: `openspec/changes/manage-clients-projects-and-sectors/design.md` (line 17)

- [x] **R4.2** Fix "Blogus" typo in tasks.md
  - **Reason**: Tasks reference "Blogus" but Bogus is used
  - **Files**: `openspec/changes/manage-clients-projects-and-sectors/tasks.md` (lines 50-54, 58-61)

### Package Version & Security Fixes

- [x] **R5.1** Fix MediatR version conflict
  - **Issue**: MediatR 12.0.0 resolved but MediatR.Extensions.Microsoft.DependencyInjection 11.1.0 requires MediatR < 12.0.0
  - **Action**: Downgrade MediatR to 11.x or upgrade MediatR.Extensions.Microsoft.DependencyInjection

- [x] **R5.2** Update AutoMapper to fix vulnerability (GHSA-rvv3-g6hj-g44x)
  - **Issue**: AutoMapper 10.1.1 has known high severity vulnerability
  - **Action**: Upgrade AutoMapper to latest secure version

- [x] **R5.3** Update Microsoft.OpenApi to fix vulnerability
  - **Issue**: Microsoft.OpenApi 3.1.1 has known vulnerability
  - **Action**: Upgrade to latest secure version

### Code Cleanup (Drift Removal)

- [x] **R6.1** Remove WeatherForecast template code from Program.cs
  - **Reason**: Template code not in specs
  - **Files**: `src/Poc.SDD.Api/Program.cs`

- [x] **R6.2** Remove Class1.cs template files
  - **Reason**: Template artifacts not in specs
  - **Files**: `src/Poc.SDD.Domain/Class1.cs`, `src/Poc.SDD.Application/Class1.cs`, `src/Poc.SDD.Infrastructure/Class1.cs`

- [x] **R6.3** Fix "Blogus" typo to "Bogus" in design.md and tasks.md
  - **Reason**: Design.md says "Blogus" but Bogus is used (typo)
  - **Files**: `design.md` line 17, `tasks.md` lines 50-54, 58-61

### Test Fixes & Verification

- [x] **V1.1** Fix API versioning in test client (CustomWebApplicationFactory)
  - **Issue**: Tests fail with "ApiVersionUnspecified"
  - **Action**: Add `client.DefaultRequestHeaders.Add("api-version", "1.0")` in factory

- [x] **V1.2** Fix Domain.IntegrationTests project configuration
  - **Issue**: "Solution root could not be located"
  - **Action**: Fix project configuration or WebApplicationFactory setup

- [x] **V1.3** Run all tests and verify pass
  - **Target**: All 71 tests passing (currently 3 failing + 1 build error)
  - **Action**: Run `dotnet test` and verify 0 failures

- [x] **V1.4** Remove template drift code
  - Remove WeatherForecast endpoints from Program.cs
  - Remove Class1.cs template files from all projects
  - Fix Bogus → Bogus typo in design.md and tasks.md

### Verification

- [x] **V2.1** Run `dotnet build` - verify no compilation errors
- [x] **V2.2** Run `dotnet test` - verify all tests pass (target: 0 failures)
- [x] **V2.3** Verify all tasks marked [x] are actually implemented
- [x] **V2.4** Update tasks.md to mark remediation tasks as [x] when complete
