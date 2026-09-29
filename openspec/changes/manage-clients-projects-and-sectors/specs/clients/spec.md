# Spec Delta

## Purpose

Full management of system clients, including creation, consultation, and tracking of client relationships.

## ADDED Requirements

### Requirement: Client can be created

The system SHALL allow creating a client with name, email and phone.

#### Scenario: Client created successfully

- **WHEN** the user completes the client form with valid data
- **THEN** the system saves the client and shows a confirmation message

### Requirement: Client can be consulted

The system SHALL allow consulting a client by its ID.

#### Scenario: Successful client consultation by ID

- **WHEN** the user requests the information of an existing client
- **THEN** the system returns the corresponding client data

### Requirement: Client can be updated

The system SHALL allow updating the data of an existing client.

#### Scenario: Successful client update

- **WHEN** the user modifies the data of an existing client and saves
- **THEN** the system updates the client data and confirms the changes