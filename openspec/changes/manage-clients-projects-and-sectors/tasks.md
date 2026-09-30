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

- [x] 7.1 Create Client unit tests with xUnit, Moq, and Blogus
- [x] 7.2 Create Project unit tests with xUnit, Moq, and Blogus
- [x] 7.3 Create Sector unit tests with xUnit, Moq, and Blogus
- [x] 7.4 Create command handler tests for all CRUD operations with xUnit, Moq, and Blogus
- [x] 7.5 Create query handler tests for all queries with xUnit, Moq, and Blogus

## 8. Integration Tests

- [x] 8.1 Implement integration test suite for API endpoints with xUnit, Moq, and Blogus
- [x] 8.2 Test client creation, consultation, and update flow with xUnit, Moq, and Blogus
- [x] 8.3 Test project creation with client assignment with xUnit, Moq, and Blogus
- [x] 8.4 Test sector assignment to clients and projects with xUnit, Moq, and Blogus

## 9. Documentation

- [x] 9.1 Update API documentation with new endpoints
- [x] 9.2 Document domain models and relationships
- [x] 9.3 Create setup guide for DDD architecture

## 10. Final Verification

- [x] 10.1 Run all unit tests and verify pass
- [x] 10.2 Run integration tests and verify flows
- [x] 10.3 Build solution and verify no compilation errors

## 11. Reorganization & Implementation Tasks

- [ ] 11.1 **Move files to correct directory structure**:
  - [ ] 11.1.1 Create `src/` and `test/` directories if they do not exist.
  - [ ] 11.1.2 Move all source code from the project root into `src/`.
  - [ ] 11.1.3 Move all test files from the project root into `test/`.
- [ ] 11.2 **Update references and imports**:
  - [ ] 11.2.1 Fix import/require paths across all files in `src/` and `test/`.
  - [ ] 11.2.2 Adjust test runner configuration (e.g., `jest.config.js`, `vitest.config.js`, or equivalent) to look for tests within `test/`.