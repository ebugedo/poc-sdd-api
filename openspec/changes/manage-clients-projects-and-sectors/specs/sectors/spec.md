# Spec Delta

## Purpose

Management of sectors to categorize system clients and projects.

## ADDED Requirements

### Requirement: Sector can be created

The system SHALL allow creating a sector with name and description.

#### Scenario: Sector created successfully

- **WHEN** the user completes the sector form with valid data
- **THEN** the system saves the sector and makes it available for assignment

### Requirement: Sector can be assigned to a client

The system SHALL allow assigning a sector to a client.

#### Scenario: Successful sector assignment to a client

- **WHEN** the user selects a sector and assigns it to an existing client
- **THEN** the system records the association between the sector and the client

### Requirement: Sector can be assigned to a project

The system SHALL allow assigning a sector to a project.

#### Scenario: Successful sector assignment to a project

- **WHEN** the user selects a sector and assigns it to an existing project
- **THEN** the system records the association between the sector and the project