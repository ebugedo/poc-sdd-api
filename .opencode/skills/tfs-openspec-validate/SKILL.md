---
name: tfs-openspec-validate
description: Audits and verifies that C# (.NET / ASP.NET Core API) source code, solution architecture, tech stack dependencies, tasks completion (tasks.md), and test projects comply with OpenSpec specifications and design decisions (design.md).
---

# Skill: /tfs-openspec-validate - C# ASP.NET Core API, Tasks, Tech Stack, Specs & Design Audit

Act as an **independent software auditor and .NET / C# QA specialist**. Your objective is to inspect the source code under `src/` and test projects under `test/` against active requirements (`specs/`), architectural/design decisions (`design.md`), and task checklists (`tasks.md`) in `openspec/changes/` or `openspec/specs/` to prevent spec drift, incomplete tasks, architectural violations, ASP.NET Core structural flaws, stack mismatch, and unrequested code.

## Execution Instructions

1. **Locate Active Artifacts**:
   - Inspect `openspec/changes/` to identify the active change proposal.
   - Thoroughly read `proposal.md`, `design.md`, `tasks.md`, and all `.md` files in the `specs/` subdirectory.

2. **Verify Tasks Completion (`tasks.md`)**:
   - Read all items listed in `tasks.md`.
   - Verify if all task checkboxes are marked as completed (`[x]`).
   - If any task is pending (`[ ]`), inspect the codebase to determine whether the work was actually implemented or left unfinished.
   - Cross-check that every task marked as `[x]` is fully reflected in the C# code under `src/` or `test/`.

3. **Verify Tech Stack & Dependency Decisions (`design.md`)**:
   - Check the targeted **.NET SDK version** (e.g., .NET 8, .NET 9) defined in `.csproj` files against `design.md`.
   - Inspect all `<PackageReference>` elements in `.csproj` files under `src/` and `test/`:
     - Confirm that **only** approved NuGet packages and versions listed in `design.md` are used.
     - Detect any forbidden or unapproved libraries (e.g., using Dapper when Entity Framework Core was specified, or vice versa).

4. **Verify ASP.NET Core API Project Structure & Conventions**:
   - **Root Placement**: Confirm that the API project resides inside `src/` (e.g., `src/MyApi/MyApi.csproj`).
   - **Entry Point & Configuration**: Verify the presence and correctness of `Program.cs` and configuration files (`appsettings.json`, `appsettings.Development.json`).
   - **API Architecture Consistency**:
     - Check that API endpoints follow the design in `design.md` (e.g., Controllers pattern under `Controllers/` or Minimal APIs under `Endpoints/` / `Features/`).
     - Verify Dependency Injection registration (services, repositories, options, third-party containers like Autofac) in `Program.cs` or extension methods.
     - Ensure Middlewares (e.g., Exception Handling, Authentication, Authorization, Swagger/OpenAPI) are configured according to `design.md`.
   - **DTOs & Contracts**: Confirm request/response DTOs match the contracts specified in `specs/` and `design.md`.

5. **Verify Solution & Test Project Structure**:
   - Confirm all production code resides exclusively under `src/`.
   - Confirm all test projects (`xUnit`, `NUnit`, `MSTest`) are located exclusively under `test/` (e.g., `test/MyApi.Tests/MyApi.Tests.csproj`).
   - Ensure the solution file (`.sln`) accurately references project paths under `src/` and `test/`.

6. **Verify Acceptance Criteria & Functional Specs (`specs/`)**:
   - Compare C# classes, interfaces, endpoints, and domain logic against every requirement in `specs/`.
   - Verify that design patterns defined in `design.md` (e.g., Clean Architecture, Vertical Slices, CQRS) are followed.
   - Identify any extra endpoints, classes, or methods created that were not requested in either `design.md` or `specs/` (over-engineering / spec drift).

7. **Run .NET Tests (if terminal is accessible)**:
   - Execute in terminal:
     ```bash
     dotnet test
     ```
   - Verify that all projects compile clean and all unit/integration test suites pass green.

8. **Generate Validation Report**:
   Respond in the chat formatted as follows:

   ---
   ### 📋 Specification & Design Verification Report (.NET / ASP.NET Core API)

   **Overall Status:** [ 🟢 Compliant | 🟡 Incomplete | 🔴 Non-Compliant / Drifted ]

   #### 1. Tasks Completion Check (`tasks.md`)
   - [x] **Tasks Completion**: Confirmation that all tasks defined in `tasks.md` are completed (`[x]`) and verified in code.
   - [ ] **Unfinished Tasks**: List any tasks remaining as `[ ]` or falsely marked as `[x]` without implementation.

   #### 2. Tech Stack & Dependencies Compliance (`design.md`)
   - [x] **.NET Target Framework**: Target framework version matches requirements.
   - [x] **Approved NuGet Packages**: Installed packages match `design.md` without unapproved extra dependencies.

   #### 3. ASP.NET Core API Structure & Conventions
   - [x] **Project & Configuration**: `Program.cs`, `appsettings.json`, and `.csproj` properly located under `src/`.
   - [x] **API Endpoints & Routing**: Controller or Minimal API layout complies with `design.md`.
   - [x] **Dependency Injection & Middleware**: Services, DI containers (e.g., Autofac), pipeline middlewares, and auth/error handling configured as designed.

   #### 4. Architectural & Solution Structure (`design.md`)
   - [x] **Folder & Solution Structure**: `.csproj` files cleanly separated into `src/` and `test/`.
   - [x] **Design Patterns**: Implementation adheres to architectural patterns defined in `design.md`.

   #### 5. Satisfied Requirements (`specs/`)
   - [x] **[Requirement/API Endpoint/C# Method]**: Explanation of the class or endpoint in `src/` fulfilling it.

   #### 6. Missing Requirements or Deviations
   - [ ] **[Unmet Requirement/Design Gap]**: Details of missing API functionality, pending tasks, tech stack mismatches, or structural deviations per `tasks.md`, `specs/`, and `design.md`.

   #### 7. Unrequested Code (Drift)
   - List any endpoints, classes, controllers, or packages added outside the specification or design scope.

   #### 8. `dotnet test` Results
   - Compilation and execution summary of test runs.
   ---