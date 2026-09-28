# Spec Delta

## Purpose

Gestión de sectores para categorizar clientes y proyectos del sistema.

## ADDED Requirements

### Requirement: Sector puede ser creado

El sistema SHALL permitir crear un sector con nombre y descripción.

#### Scenario: Sector creado exitosamente

- **WHEN** el usuario completa el formulario de sector con datos válidos
- **THEN** el sistema guarda el sector y está disponible para asignación

### Requirement: Sector puede ser asignado a cliente

El sistema SHALL permitir asignar un sector a un cliente.

#### Scenario: Asignación de sector a cliente exitosa

- **WHEN** el usuario selecciona un sector y lo asigna a un cliente existente
- **THEN** el sistema registra la asociación entre el sector y el cliente

### Requirement: Sector puede ser asignado a proyecto

El sistema SHALL permitir asignar un sector a un proyecto.

#### Scenario: Asignación de sector a proyecto exitosa

- **WHEN** el usuario selecciona un sector y lo asigna a un proyecto existente
- **THEN** el sistema registra la asociación entre el sector y el proyecto