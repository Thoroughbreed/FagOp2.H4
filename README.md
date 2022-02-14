# FagOp2.H4
Faglig opdatering 2 - WebAPI og sikkerhed

| Endpoint                   | Description                   | Request body | Response body        |
|----------------------------|-------------------------------|--------------|----------------------|
| GET /                      | Browser test, "Hello World"   | None         | Hello World!         |
| GET /todoitems             | Get non-completed to-do items | None         | Array of to-do items |
| GET /todoitems/complete    | Get all to-do items           | None         | Array of to-do items |
| GET /todoitems/{id}        | Get an item by ID             | None         | To-do item           |
| POST /todoitems            | Add a new item                | To-do item   | To-do item           |
| PUT /todoitems/{id}        | Update an item by ID          | To-do item   | None                 |
| DELETE /todoitems/{id}     | Delete an item by ID          | None         | None                 |
