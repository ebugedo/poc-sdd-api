# Tasks

## 1. DDD Architecture Setup

- [ ] 1.1 Crear solución DDD con proyectos: Domain, Application, Infrastructure, Api
- [ ] 1.2 Mover entidades domain (Cliente, Proyecto, Sector) al proyecto Domain
- [ ] 1.3 Definir agregados y value objects en el proyecto Domain
- [ ] 1.4 Configurar Entity Framework Core en el proyecto Infrastructure
- [ ] 1.5 Configurar AutoMapper entre capas Domain → Application → Api
- [ ] 1.5 Configurar MediatR para comandos y queries en el proyecto Application
- [ ] 1.6 Configurar inyección de dependencias Autofac en el proyecto Api

## 2. Domain Layer (Cliente)

- [ ] 2.1 Definir entidad Cliente con Id, Nombre, Email, Telefono
- [ ] 2.2 Definir value objects (ClienteName, ClientEmail) si aplica
- [ ] 2.3 Implementar repositorio interface IClienteRepository en Domain
- [ ] 2.4 Implementar dominio/agregado Cliente con lógica de negocio

## 3. Application Layer (Cliente)

- [ ] 3.1 Crear comandos: CreateClienteCommand, UpdateClienteCommand, DeleteClienteCommand
- [ ] 3.2 Crear queries: GetClienteQuery, GetClientesQuery
- [ ] 3.3 Implementar handlers para cada comando/query usando MediatR
- [ ] 3.4 Implementar servicios de aplicación (ClienteAppService) con lógica de caso de uso

## 4. Infrastructure Layer (Cliente)

- [ ] 4.1 Implementar repositorio EfCoreClienteRepository que implemente IClienteRepository
- [ ] 4.2 Configurar DbContext y mapeo de entidades en Infrastructure
- [ ] 4.3 Configurar conexión a base de datos y migrations

## 5. API Layer (Cliente)

- [ ] 5.1 Crear Controlador ClientsController que delegue a Application services
- [ ] 5.2 Configurar enrutado API: api/v1/clientes
- [ ] 5.3 Agregar validación de modelo y manejo de errores HTTP
- [ ] 5.4 Agregar XML comments en los controladores

## 6. Domain Layer (Proyecto)

- [ ] 6.1 Definir entidad Proyecto con Id, Nombre, Descripción, FechaCreación
- [ ] 6.2 Definir value objects si aplica
- [ ] 6.3 Implementar repositorio interface IProyectoRepository en Domain
- [ ] 6.4 Implementar dominio/agregado Proyecto con lógica de negocio

## 7. Application Layer (Proyecto)

- [ ] 7.1 Crear comandos: CreateProyectoCommand, UpdateProyectoCommand, DeleteProyectoCommand
- [ ] 7.2 Crear queries: GetProyectoQuery, GetProyectosQuery
- [ ] 7.3 Implementar handlers para cada comando/query usando MediatR
- [ ] 7.4 Implementar servicios de aplicación (ProyectoAppService) con lógica de caso de uso

## 8. Infrastructure Layer (Proyecto)

- [ ] 8.1 Implementar repositorio EfCoreProyectoRepository que implemente IProyectoRepository
- [ ] 8.2 Configurar DbContext y mapeo de entidades (ya configurado en tarea 4)

## 9. API Layer (Proyecto)

- [ ] 9.1 Crear Controlador ProyectosController que delegue a Application services
- [ ] 9.2 Agregar enrutado API: api/v1/proyectos
- [ ] 9.3 Agregar validación y manejo de errores HTTP

## 10. Domain Layer (Sectores)

- [ ] 10.1 Definir entidad Sector con Id, Nombre, Descripción
- [ ] 10.2 Definir value objects si aplica
- [ ] 10.3 Implementar repositorio interface ISectorRepository en Domain
- [ ] 10.4 Implementar dominio/agregado Sector con lógica de negocio

## 11. Application Layer (Sectores)

- [ ] 11.1 Crear comandos: CreateSectorCommand, UpdateSectorCommand, DeleteSectorCommand
- [ ] 11.2 Crear queries: GetSectorQuery, GetSectoresQuery
- [ ] 11.3 Implementar handlers para cada comando/query usando MediatR
- [ ] 11.4 Implementar servicios de aplicación (SectorAppService) con lógica de caso de uso

## 12. Infrastructure Layer (Sectores)

- [ ] 12.1 Implementar repositorio EfCoreSectorRepository que implemente ISectorRepository
- [ ] 12.2 Configurar mapeo de entidad Sector (ya configurado en tarea 4)

## 13. API Layer (Sectores)

- [ ] 13.1 Crear Controlador SectoresController que delegue a Application services
- [ ] 13.2 Agregar enrutado API: api/v1/sectores
- [ ] 13.3 Agregar validación y manejo de errores HTTP

## 14. Integración y Pruebas

- [ ] 14.1 Ejecutar migraciones de base de datos para crear esquema
- [ ] 14.2 Ejecutar API y verificar endpoints: GET/POST/PUT/DELETE en /api/v1/clientes, /api/v1/proyectos, /api/v1/sectores
- [ ] 14.3 Implementar pruebas unitarias con xUnit y Moq para handlers y servicios
- [ ] 14.4 Probar integración de dominio-aplicación-infraestructura
- [ ] 14.5 Documentación final y revisión

## 15. Review and Sign-off

- [ ] 15.1 Revisar estructura completa DDD y arquitectura de capas
- [ ] 15.2 Verificar que todas las dependencias entre capas sean correctas
- [ ] 15.3 Firma final y documentación del patrón adoptado