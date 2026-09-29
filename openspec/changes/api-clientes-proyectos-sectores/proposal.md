# Proposal

## Why

El sistema necesita exponer una API Rest para que el front y otros sistemas externos puedan consumir los servicios de clientes, proyectos y sectores. Actualmente no existe una API unificada que integre estos tres dominios empresariales.

## What Changes

- Nueva API Rest para exposición de servicios de clientes, proyectos y sectores

## Capabilities

### New Capabilities

- `clientes`: API Rest para gestión completa de clientes (CRUD, consulta, asociación)
- `proyectos`: API Rest para gestión completa de proyectos (CRUD, consulta, asociación a clientes)
- `sectores`: API Rest para gestión y asignación de sectores

### Modified Capabilities

*Empty - no existing capabilities modified*

## Impact

- Nuevos endpoints REST API bajo /api/v1/clientes, /api/v1/proyectos, /api/v1/sectores
- Controladores y servicios para los tres dominios
- Modelos de datos para clientes, proyectos y sectores con relaciones Many-to-Many
- Documentación de API (OpenAPI/Swagger)
- Integración con front-end y sistemas externos