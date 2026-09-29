# Design

## Context

Sistema actual sin API Rest unificada para exponer servicios de clientes, proyectos y sectores. Se requiere diseñar la arquitectura para soportar estos tres dominios con APIs REST coherentes y reutilizables.

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
- Implementar API Rest completa para clientes, proyectos y sectores
- Establecer endpoints RESTful consistentes (/api/v1/clientes, /api/v1/proyectos, /api/v1/sectores)
- Proporcionar autenticación y autorización en los endpoints
- Diseñar para que el front-end y otros sistemas puedan consumir las APIs

**Non-Goals:**
- Implementación del front-end (API only)
- Migración de datos existentes (fuera de alcance)
- Reportes y analytics avanzados

## Decisions

- **Arquitectura RESTful**: Los endpoints seguirán convenciones REST con recursos nombrados en plural
- **API Versioning**: Los endpoints usarán versión v1 en la URL (/api/v1/...)
- **JSON Format**: Todas las respuestas y peticiones usarán formato JSON
- **Capas separadas**: Controladores, servicios y repositorios separados por dominio
- **Seguridad**: JWT tokens para autenticación en todos los endpoints

## Risks / Trade-offs

[Risk] Complejidad en las relaciones Many-to-Many entre clientes-proyectos y proyectos-sectores
[Mitigation] Implementar validación en capa de servicio y usar transacciones de base de datos

[Risk] Superposición de lógica entre diferentes controladores
[Mitigation] Crear capas de servicio base reutilizables con patrones comunes

[Risk] Versionado de API en el futuro
[Mitigation] Diseñar endpoints con sufijo de versión (/api/v1/) para facilitar migraciones futuras