# Spec Delta

## Purpose

Management of projects associated with clients, including creation, assignment, and progress tracking.

## ADDED Requirements

### Requirement: Project can be created

The system SHALL allow creating a project with name, description and associated client.

#### Scenario: Project created successfully

- **WHEN** the user completes the project form with valid data and selects a client
- **THEN** the system saves the project and associates it with the selected client

### Requirement: Project can be consulted

The system SHALL allow consulting a project by its ID.

#### Scenario: Successful project consultation by ID

- **WHEN** the user requests the information of an existing project
- **THEN** the system returns the corresponding project data

### Requirement: Project can be updated

The system SHALL allow updating the data of an existing project.

#### Scenario: Successful project update

- **WHEN** the user modifies the data of an existing project and saves
- **THEN** the system updates the project data and confirms the changes