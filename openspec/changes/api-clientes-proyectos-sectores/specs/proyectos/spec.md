# Spec Delta

## Purpose

API Rest para gestión de proyectos asociados a clientes, incluyendo creación, consulta y seguimiento de progreso.

## ADDED Requirements

### Requirement: Proyecto puede ser creado

El sistema SHALL permitir crear un proyecto con nombre, descripción y cliente asociado a través de la API REST.

#### Scenario: Proyecto creado exitosamente mediante API

- **WHEN** el front-end envía un POST a /api/v1/proyectos con datos válidos y clienteId
- **THEN** el sistema guarda el proyecto y lo asocia al cliente indicado, devuelve 201 Created

### Requirement: Proyecto puede ser consultado

El sistema SHALL permitir consultar un proyecto por su ID a través de la API REST.

#### Scenario: Consulta de proyecto por ID exitosa

- **WHEN** el front-end solicita GET /api/v1/proyectos/{id} para un proyecto existente
- **THEN** el sistema devuelve 200 OK con los datos del proyecto correspondientes

### Requirement: Proyecto puede ser actualizado

El sistema SHALL permitir actualizar los datos de un proyecto existente a través de la API REST.

#### Scenario: Actualización de proyecto exitosa

- **WHEN** el front-end envía un PUT a /api/v1/proyectos/{id} con datos modificados
- **THEN** el sistema actualiza los datos del proyecto y devuelve 200 OK con los datos actualizados

### Requirement: Proyecto puede ser asociado a cliente

El sistema SHALL permitir asociar un proyecto a un cliente a través de la API REST.

#### Scenario: Asociación proyecto-cliente exitosa

- **WHEN** el front-end envía un POST a /api/v1/proyectos/{id}/clientes con un clienteId
- **THEN** el sistema asociar el cliente al proyecto y devuelve 200 OK