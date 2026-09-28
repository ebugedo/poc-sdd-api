# Spec Delta

## Purpose

Gestión completa de clientes del sistema, incluyendo creación, consulta y seguimiento de relaciones con clientes.

## ADDED Requirements

### Requirement: Cliente puede ser creado

El sistema SHALL permitir crear un cliente con nombre, email y teléfono.

#### Scenario: Cliente creado exitosamente

- **WHEN** el usuario completa el formulario de cliente con datos válidos
- **THEN** el sistema guarda el cliente y muestra mensaje de confirmación

### Requirement: Cliente puede ser consultado

El sistema SHALL permitir consultar un cliente por su ID.

#### Scenario: Consulta de cliente por ID exitosa

- **WHEN** el usuario solicita la información de un cliente existente
- **THEN** el sistema devuelve los datos del cliente correspondientes

### Requirement: Cliente puede ser actualizado

El sistema SHALL permitir actualizar los datos de un cliente existente.

#### Scenario: Actualización de cliente exitosa

- **WHEN** el usuario modifica los datos de un cliente existente y guarda
- **THEN** el sistema actualiza los datos del cliente y confirma los cambios