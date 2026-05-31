# TaskManager

A simple .NET 10 Web API for managing tasks in memory.

## Project Structure

- `TaskManager.API/` - ASP.NET Core Web API project.
- `TaskManager.Application/` - Application service layer with task management logic.
- `TaskManager.Domain/` - Domain model definitions.

## Overview

This application exposes REST endpoints to create, retrieve, delete, and toggle completion status for tasks. It uses an in-memory singleton `TaskService`, so state is kept only while the application is running.

## Features

- `GET /api/tasks` - Retrieve all tasks.
- `GET /api/tasks/{id}` - Retrieve a task by ID.
- `POST /api/tasks` - Create a new task.
- `DELETE /api/tasks/{id}` - Delete a task.
- `PATCH /api/tasks/{id}/complete` - Toggle a task's completion state.

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Run Locally

From the repository root:

```powershell
cd "c:\Users\crres\OneDrive\Desktop\SKILL DEV\DOTNET\TaskManager"
dotnet run --project TaskManager.API\TaskManager.API.csproj
```

The API will start using the default configuration from `TaskManager.API`.

### Build

```powershell
dotnet build TaskManager.slnx
```

## API Endpoints

### Create Task

```http
POST /api/tasks
Content-Type: application/json

{
  "title": "My Task",
  "description": "Description of the task"
}
```

### Get All Tasks

```http
GET /api/tasks
```

### Get Task by ID

```http
GET /api/tasks/{id}
```

### Delete Task

```http
DELETE /api/tasks/{id}
```

### Toggle Task Completion

```http
PATCH /api/tasks/{id}/complete
```

## Notes

- Task management is implemented in `TaskManager.Application.TaskService`.
- `TaskItem` is defined in `TaskManager.Domain.TaskItem`.
- The API adds OpenAPI support via `Microsoft.AspNetCore.OpenApi`.

## License

This repository does not specify a license.
