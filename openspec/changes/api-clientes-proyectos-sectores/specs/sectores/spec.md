# Spec Delta

## Purpose

API Rest para gestión y asignación de sectores, incluyendo creación y asignación a clientes y proyectos.

## ADDED Requirements

### Requirement: Sector puede ser creado

El sistema SHALL permitir crear un sector con nombre y descripción a través de la API REST.

#### Scenario: Sector creado exitosamente mediante API

- **WHEN** el front-end envía un POST a /api/v1/sectores con datos válidos
- **THEN** el sistema guarda el sector y devuelve 201 Created con los datos del sector creado

### Requirement: Sector puede ser asignado a cliente

El sistema SHALL permitir asignar un sector a un cliente a través de la API REST.

#### Scenario: Asignación sector-cliente exitosa

- **WHEN** el front-end envía un POST a /api/v1/sectores/{id}/clientes con un clienteId
- **THEN** el sistema asigna el sector al cliente y devuelve 200 OK

### Requirement: Sector puede ser asignado a proyecto

El sistema SHALL permitir asignar un sector a un proyecto a través de la API REST.

#### Scenario: Asignación sector-proyecto exitosa

- **WHEN** el front-end envía un POST a /api/v1/sectores/{id}/proyectos con un proyectoId
- **THEN** el sistema asigna el sector al proyecto y devuelve 200 OK