# Proposal

## Why

The system needs integrated management of clients, projects, and sectors. There is no unified solution that coordinates these three business domains coherently.

## What Changes

- New client management capability
- New project management capability
- New sector management capability

## Capabilities

### New Capabilities

- `clients`: Capability for managing clients, including creation, consultation, and tracking of client relationships
- `projects`: Capability for managing projects, including project creation, assignment to clients, and progress tracking
- `sectors`: Capability for managing sectors, including sector categorization and sector-client-project relationships

### Modified Capabilities

*Empty - no existing capabilities modified*

## Impact

- New API modules for CRUD of clients, projects, and sectors
- Data models for clients, projects, and sectors with Many-to-Many relationships
- Association endpoints between clients and projects, and between projects and sectors
- Possible impact on existing databases and schemas