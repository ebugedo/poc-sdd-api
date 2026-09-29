# Design

## Context

Sistema existente sin gestión integrada de clientes, proyectos y sectores. Se requiere diseñar la arquitectura usando Domain-Driven Design (DDD) en C# para soportar estos tres dominios con relaciones Many-to-Many y APIs coherentes.

## Tecnologías

Las siguientes tecnologías serán utilizadas en el proyecto:
- **DDD**: Domain-Driven Design para el modelado del dominio y límites acotados
- **CQRS**: Separación de lecturas y escrituras mediante comandos y queries
- **Autofac**: Inyección de dependencias para el ensamblaje de componentes
- **Automapper**: Mapeo objeto-objeto entre capas y DTOs
- **xUnit**: Framework de pruebas unitarias
- **Moq**: Biblioteca de mocks para pruebas unitarias
- **Blogus**: Biblioteca de utilidades internas del proyecto

## Project Structure (DDD)

La solución seguirá una arquitectura en capas DDD con los siguientes proyectos:

- **Domain**: Contiene los agregados, entidades, value objects y dominios específicos del negocio. No depende de ninguna otra capa.
- **Application**: Contiene los casos de uso (use cases), comandos, queries, manejadores y servicios de aplicación. Depend de Domain únicamente.
- **Infrastructure**: Implementación de repositorios, Entity Framework Core DbContext, servicios externos y otras preocupaciones técnicas. Depend de Domain y Application.
- **Api**: Proyecto ASP.NET Core Web API que expone los endpoints. Depend de Application exclusivamente.

## Goals / Non-Goals

**Goals:**
- Implementar arquitectura DDD completa para clientes, proyectos y sectores
- Separación clara de responsabilidades entre capas
- API REST consistente siguiendo convenciones REST con `/api/v1/clientes`, `/api/v1/proyectos`, `/api/v1/sectores`
- Testabilidad mediante xUnit y Moq

**Non-Goals:**
- Migración de datos existentes (fuera de alcance actual)
- Interfaz de usuario front-end (back-end only)
- Reportes y analytics avanzados

## Decisions

### DDD Architecture Decisions:

- **Domain Layer**: Cada dominio (Cliente, Proyecto, Sector) será un proyecto/class library separado con sus agregados, entidades y value objects. Sin referencias a infraestructura o APIs.
- **Application Layer**: Los casos de uso estarán organizados por dominio (Commands, Queries, Handlers). Cada handler implementa una operación específica del negocio.
- **Infrastructure Layer**: Entity Framework Core para persistencia, repositorios genéricos y específicos. Configuración de mapeo OOP a tabla relacional.
- **API Layer**: Controladores minimalistas que deleguen toda la lógica al Application layer. Solo responsable de validación HTTP y formateo de respuestas.

### API Design Decisions:

- **API Versioning**: Los endpoints usarán versión v1 en la URL (`/api/v1/...`)
- **Resource Naming**: Recursos en plural (`clientes`, `proyectos`, `sectores`)
- **HTTP Methods**: CRUD estándar (GET, POST, PUT, DELETE)
- **DTO Mapping**: AutoMapper para mapear entre entidades Domain y DTOs de API

### CQRS Decisions:

- **Commands**: Operaciones de escritura (crear, actualizar, eliminar) que modifican el estado del sistema
- **Queries**: Operaciones de lectura que devuelven datos sin modificar el estado
- **MediatR**: Patrón para enviar comandos/queries y recibir handlers

## Risks / Trade-offs

[Risk] Complejidad adicional al separar múltiples capas en proyectos distintos
[Mitigation] Mantener interfaces claras y mínimas entre capas; usar automatización para reducir código repetitivo

[Risk] Curva de aprendizaje para el equipo al adoptar patrones DDD y CQRS
[Mitigation] Documentación completa y ejemplos de implementación; empezar con casos de uso simples

[Risk] Over-engineering para un proyecto de tamaño mediano
[Mitigation] Empezar con lo esencial y agregar complejidad gradualmente según sea necesario

[Risk] Consistencia entre el modelo domain y la base de datos
[Mitigation] Usar Entity Framework Core con configuración fuerte y pruebas de integración