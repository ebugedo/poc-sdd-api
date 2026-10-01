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

## 11. Reorganization & Implementation Tasks (Legacy)

- [ ] 11.1 **Move files to correct directory structure**:
  - [ ] 11.1.1 Create `src/` and `test/` directories if they do not exist.
  - [ ] 11.1.2 Move all source code from the project root into `src/`.
  - [ ] 11.1.3 Move all test files from the project root into `test/`.
- [ ] 11.2 **Update references and imports**:
  - [ ] 11.2.1 Fix import/require paths across all files in `src/` and `test/`.
  - [ ] 11.2.2 Adjust test runner configuration (e.g., `jest.config.js`, `vitest.config.js`, or equivalent) to look for tests within `test/`.

(End of file - total 111 lines)