# Design

## Context

Existing system without integrated management of clients, projects, and sectors. Designing the architecture using Domain-Driven Design (DDD) in C# is required to support these three domains with Many-to-Many relationships and consistent APIs.

## Technologies

The following technologies will be used in the project:

- **DDD**: Domain-Driven Design for domain modeling and bounded contexts
- **CQRS**: Separation of reads and writes via commands and queries
- **Autofac**: Dependency injection for component assembly
- **Automapper**: Object-object mapping between layers and DTOs
- **xUnit**: Unit testing framework
- **Moq**: Mock library for unit tests
- **Blogus**: Internal project utilities library

## Project Structure (DDD)

The solution will follow a layered DDD architecture with the following projects:

- **Domain**: Contains aggregates, entities, value objects, and specific business domains. Does not depend on any other layer.
- **Application**: Contains use cases, commands, queries, handlers, and application services. Depends only on Domain.
- **Infrastructure**: Implementation of repositories, Entity Framework Core DbContext, external services, and other technical concerns. Depends on Domain and Application.
- **Api**: ASP.NET Core Web API project that exposes endpoints. Depends exclusively on Application.

## Goals / Non-Goals

**Goals:**
- Implement complete DDD architecture for clients, projects, and sectors
- Clear separation of responsibilities between layers
- Consistent REST API following REST conventions with `/api/v1/clientes`, `/api/v1/proyectos`, `/api/v1/sectores`
- Testability using xUnit and Moq

**Non-Goals:**
- Existing data migration (out of current scope)
- Front-end user interface (back-end only)
- Advanced reporting and analytics

## Decisions

### DDD Architecture Decisions:

- **Domain Layer**: Each domain (Client, Project, Sector) will be a separate class library with its aggregates, entities, and value objects. No references to infrastructure or APIs.
- **Application Layer**: Use cases will be organized by domain (Commands, Queries, Handlers). Each handler implements a specific business operation.
- **Infrastructure Layer**: Entity Framework Core for persistence, generic and specific repositories. OOP to relational table mapping configuration.
- **API Layer**: Minimalist controllers that delegate all logic to the Application layer. Only responsible for HTTP validation and response formatting.

### API Design Decisions:

- **API Versioning**: Endpoints will use v1 version in the URL (`/api/v1/...`)
- **Resource Naming**: Resources in plural (`clients`, `projects`, `sectors`)
- **HTTP Methods**: Standard CRUD (GET, POST, PUT, DELETE)
- **DTO Mapping**: AutoMapper to map between Domain entities and API DTOs

### CQRS Decisions:

- **Commands**: Write operations (create, update, delete) that modify system state
- **Queries**: Read operations that return data without modifying state
- **MediatR**: Pattern for sending commands/queries and receiving handlers

## Risks / Trade-offs

[Risk] Additional complexity when separating multiple layers into distinct projects
[Mitigation] Keep clear and minimal interfaces between layers; use automation to reduce repetitive code

[Risk] Learning curve for the team adopting DDD and CQRS patterns
[Mitigation] Complete documentation and implementation examples; start with simple use cases

[Risk] Over-engineering for a medium-sized project
[Mitigation] Start with essentials and gradually add complexity as needed

[Risk] Consistency between the domain model and the database
[Mitigation] Use Entity Framework Core with strong configuration and integration tests