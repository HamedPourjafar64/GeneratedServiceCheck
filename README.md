# AuthService Microservice

## Description
AuthService microservice following Clean Architecture + CQRS patterns.

## Technology Stack
- .NET 8
- PostgreSQL
- MediatR (CQRS)
- FluentValidation
- AutoMapper
- Entity Framework Core

## Project Structure
- **Domain**: Core business entities and logic
- **Application**: CQRS commands/queries, DTOs, business logic
- **Infrastructure**: Data access, external services
- **Api**: REST API controllers, middleware

## Setup

### Prerequisites
- .NET 8 SDK
- PostgreSQL 16+
- Docker (optional)

### Database Setup

Run PostgreSQL using Docker:
```bash
docker run -d \
  --name authservice-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=AuthServiceDb \
  -p 5432:5432 \
  postgres:16
```

### Run Application
```bash
cd src/AuthService.Api
dotnet run
```

The API will be available at `http://localhost:5081`

### API Documentation
Swagger UI: http://localhost:5081/swagger

### Health Check
http://localhost:5081/health

## Development

### Build Solution
```bash
dotnet build
```

### Run Migrations
```bash
cd src/AuthService.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../AuthService.Api
dotnet ef database update --startup-project ../AuthService.Api
```

### Run Tests
```bash
dotnet test
```

## Architecture Decisions

### Clean Architecture
The project follows Clean Architecture principles with clear separation of concerns:
- **Domain**: Pure business logic, no dependencies
- **Application**: Use cases and business rules
- **Infrastructure**: External concerns (database, caching, etc.)
- **Api**: Entry point and presentation layer

### CQRS Pattern
Commands and queries are separated using MediatR for better scalability and maintainability.

### Behaviors Pipeline
MediatR behaviors handle cross-cutting concerns:
- **LoggingBehavior**: Logs all requests
- **ValidationBehavior**: Validates requests using FluentValidation
- **PerformanceBehavior**: Monitors long-running requests
- **TransactionBehavior**: Wraps commands in database transactions

### Repository Pattern
Data access is abstracted through repositories for testability and flexibility.

### Soft Delete
All entities support soft deletion for data retention and audit purposes.

### Audit Fields
All entities automatically track creation, modification, and deletion metadata.

## API Versioning
The API supports versioning through URL segments:
- v1: http://localhost:5081/api/v1/{controller}

## CORS Policy
CORS is configured to allow all origins in development. Update the policy in `Program.cs` for production.

## Health Checks
Health checks monitor:
- API availability
- Database connectivity

## Environment Variables
Configure the following in `appsettings.json` or environment variables:
- `ConnectionStrings:DefaultConnection`: PostgreSQL connection string

## Contributing
1. Create a feature branch
2. Make your changes
3. Run tests
4. Submit a pull request

## License
MIT
