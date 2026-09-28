# Proposal

## Why

Sistema actual necesita gestión integrada de clientes, proyectos y sectores. No existe una solución unificada que coordene estos tres dominios empresariales de manera coherente.

## What Changes

- Nueva capacidad de gestión de clientes
- Nueva capacidad de gestión de proyectos  
- Nueva capacidad de gestión de sectores

## Capabilities

### New Capabilities

- `clientes`: Capability for managing clients, including creation, consultation, and tracking of client relationships
- `proyectos`: Capability for managing projects, including project creation, assignment to clients, and progress tracking
- `sectores`: Capability for managing sectors, including sector categorization and sector-client-project relationships

### Modified Capabilities

*Empty - no existing capabilities modified*

## Impact

- Nuevos módulos de API para CRUD de clientes, proyectos y sectores
- Modelos de datos para clientes, proyectos y sectores con relaciones Many-to-Many
- Endpoints de asociación entre clientes y proyectos, y entre proyectos y sectores
- Posible impacto en bases de datos y esquemas existentes