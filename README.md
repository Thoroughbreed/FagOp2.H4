# FagOp2.H4
WebAPI and security

### Requirements
A to-do list with the following:
* Description
* Creation timestamp
* Completed flag
* Priority (low, normal, high)
* Specified endpoints (see below)
* .NET-6 *Minimal WebAPI Pattern*
* Support for OpenAPI (Swagger)
* ReadMe (this file)

### API Endpoints
| Endpoint                   | Description                   | Request body | Response body        |
|----------------------------|-------------------------------|--------------|----------------------|
| GET /                      | Browser test, "Hello World"   | None         | Hello World!         |
| GET /todoitems             | Get non-completed to-do items | None         | Array of to-do items |
| GET /todoitems/complete    | Get all to-do items           | None         | Array of to-do items |
| GET /todoitems/{id}        | Get an item by ID             | None         | To-do item           |
| POST /todoitems            | Add a new item                | To-do item   | To-do item           |
| PUT /todoitems/{id}        | Update an item by ID          | To-do item   | None                 |
| DELETE /todoitems/{id}     | Delete an item by ID          | None         | None                 |

### NuGet packs
| Name                      | Version | Where  |
|---------------------------|---------|--------|
| Entity Framework Core     | 6.0.2   | WebAPI |
| Entity Framework InMemory | 6.0.2   | WebAPI |
| Swashbuckle               | 6.2.3   | WebAPI |

### Completed tests
| Description               | Status    |
|---------------------------|-----------|
| Create new item           | Succeeded |
| Edit existing item        | Succeeded |
| Delete item by ID         | Succeeded |
| Show all items            | Succeeded |
| Show non-completed items  | Succeeded |
| Find item by ID           | Succeeded |

