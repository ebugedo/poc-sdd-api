# Spec Delta

## Purpose

API Rest para gestión completa de clientes, incluyendo creación, consulta, actualización y eliminación de registros de clientes.

## ADDED Requirements

### Requirement: Cliente puede ser creado

El sistema SHALL permitir crear un cliente con nombre, email y teléfono a través de la API REST.

#### Scenario: Cliente creado exitosamente mediante API

- **WHEN** el front-end envía un POST a /api/v1/clientes con datos válidos
- **THEN** el sistema guarda el cliente y devuelve 201 Created con los datos del cliente creado

### Requirement: Cliente puede ser consultado

El sistema SHALL permitir consultar un cliente por su ID a través de la API REST.

#### Scenario: Consulta de cliente por ID exitosa

- **WHEN** el front-end solicita GET /api/v1/clientes/{id} para un cliente existente
- **THEN** el sistema devuelve 200 OK con los datos del cliente correspondientes

### Requirement: Cliente puede ser actualizado

El sistema SHALL permitir actualizar los datos de un cliente existente a través de la API REST.

#### Scenario: Actualización de cliente exitosa

- **WHEN** el front-end envía un PUT a /api/v1/clientes/{id} con datos modificados
- **THEN** el sistema actualiza los datos del cliente y devuelve 200 OK con los datos actualizados

### Requirement: Cliente puede ser eliminado

El sistema SHALL permitir eliminar un cliente por su ID a través de la API REST.

#### Scenario: Eliminación de cliente exitosa

- **WHEN** el front-end envía un DELETE a /api/v1/clientes/{id}
- **THEN** el sistema elimina el cliente y devuelve 204 No Content