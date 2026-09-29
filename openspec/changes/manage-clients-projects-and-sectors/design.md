# Design

## Context

Sistema existente sin gestión integrada de clientes, proyectos y sectores. Se requiere diseñar la arquitectura para soportar estos tres dominios con relaciones Many-to-Many y APIs coherentes.

## Tecnologías

Las siguientes tecnologías serán utilizadas en el proyecto:
- **DDD**: Domain-Driven Design para el modelado del dominio y límites acotados
- **CQRS**: Separación de lecturas y escrituras mediante comandos y queries
- **Autofac**: Inyección de dependencias para el ensamblaje de componentes
- **Automapper**: Mapeo objeto-objeto entre capas y DTOs
- **xUnit**: Framework de pruebas unitarias
- **Moq**: Biblioteca de mocks para pruebas unitarias
- **Blogus**: Biblioteca de utilidades internas del proyecto

## Goals / Non-Goals

**Goals:**
- Implementar CRUD completo para clientes, proyectos y sectores
- Establecer relaciones entre clientes y proyectos, y entre proyectos y sectores
- Proporcionar API REST consistente para los tres dominios

**Non-Goals:**
- Migración de datos existentes (fuera de alcance actual)
- Interfaz de usuario front-end (back-end only)
- Reportes y analytics avanzados

## Decisions

- **Arquitectura modular**: Cada dominio (cliente, proyecto, sector) tendrá su propio módulo con controladores y servicios separados
- **API RESTful**: Endpoints seguirán convenciones REST con `/api/v1/clientes`, `/api/v1/proyectos`, `/api/v1/sectores`
- **Base de datos relacional**: Usar tablas separadas con claves foráneas para relaciones Many-to-Many entre clientes-proyectos y proyectos-sectores
- **Autenticación JWT**: Tokens de autorización para todas las APIs

## Risks / Trade-offs

[Risk] Complejidad en las relaciones Many-to-Many podría causar problemas de integridad de datos
[Mitigation] Implementar validación en capa de servicio y usar transacciones de base de datos

[Risk] Duplicación de lógica entre módulos
[Mitigation] Crear capas de servicio base reutilizables

[Risk] Performance con creciente número de relaciones
[Mitigation] Indexar columnas de clave foránea y considerar caching para lecturas frecuentes