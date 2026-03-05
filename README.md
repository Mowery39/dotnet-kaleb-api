# .NET Task API

A small REST API built using **C# and ASP.NET Core** while learning the **.NET ecosystem**.
This project demonstrates the basic structure of a backend API and implements simple CRUD-style endpoints for managing tasks.

---

## Tech Stack

* C#
* .NET
* ASP.NET Core
* Swagger / OpenAPI

---

## Features

This API currently supports basic task management.

### Endpoints

**GET /tasks**
Returns a list of all tasks.

**POST /tasks**
Adds a new task.

**DELETE /tasks/{index}**
Deletes a task at the specified index.

**GET /kaleb**
Test endpoint used to verify the API is running.

---

## Example Responses

### GET /tasks

```json
[
  "Workout",
  "Study C#",
  "Push GitHub code"
]
```

### DELETE /tasks/1

```json
[
  "Workout",
  "Push GitHub code"
]
```

---

## Running the Project

Clone the repository:

```
git clone https://github.com/Mowery39/dotnet-kaleb-api.git
cd dotnet-kaleb-api
```

Run the API:

```
dotnet run
```

Once the server starts, open Swagger in your browser:

```
http://localhost:5243/swagger
```

Swagger provides an interactive UI for testing all API endpoints.

---

## Purpose

This project was created to learn how to:

* Build REST APIs with ASP.NET Core
* Implement CRUD-style endpoints
* Understand API routing with HTTP methods
* Use Swagger for API documentation and testing
* Work with Git and GitHub during development

---

## Future Improvements

* Replace the in-memory task list with a database
* Add update functionality (PUT/PATCH)
* Introduce models and service layers
* Add authentication
* Write unit tests
