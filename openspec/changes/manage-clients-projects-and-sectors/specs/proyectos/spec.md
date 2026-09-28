# Spec Delta

## Purpose

Gestión de proyectos asociados a clientes, incluyendo creación, asignación y seguimiento de progreso.

## ADDED Requirements

### Requirement: Proyecto puede ser creado

El sistema SHALL permitir crear un proyecto con nombre, descripción y cliente asociado.

#### Scenario: Proyecto creado exitosamente

- **WHEN** el usuario completa el formulario de proyecto con datos válidos y selecciona un cliente
- **THEN** el sistema guarda el proyecto y lo asocia al cliente seleccionado

### Requirement: Proyecto puede ser consultado

El sistema SHALL permitir consultar un proyecto por su ID.

#### Scenario: Consulta de proyecto por ID exitosa

- **WHEN** el usuario solicita la información de un proyecto existente
- **THEN** el sistema devuelve los datos del proyecto correspondientes

### Requirement: Proyecto puede ser actualizado

El sistema SHALL permitir actualizar los datos de un proyecto existente.

#### Scenario: Actualización de proyecto exitosa

- **WHEN** el usuario modifica los datos de un proyecto existente y guarda
- **THEN** el sistema actualiza los datos del proyecto y confirma los cambios