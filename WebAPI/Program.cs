using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.DAL;
using WebAPI.DTO;
using WebAPI.Models;
using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

#region API Endpoints

// GET - default, all non-completed
    app.MapGet("/todoitems", async (TodoDb db) =>
    {
        var items = await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync();
        return items.Where(x => x.Completed == false);
    });

// GET - all items
    app.MapGet("/todoitems/all", async (TodoDb db) =>
        await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync());

// GET - item by ID
    app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
        await db.Todos.FindAsync(id) is Todo todo ? Ok(new TodoItemDTO(todo)) : NotFound());

// POST - new item
    app.MapPost("/todoitems", async (TodoItemDTO todoItemDTO, TodoDb db) =>
    {
        var todoItem = new Todo
        {
            Completed = todoItemDTO.Completed,
            Description = todoItemDTO.Description,
            Priority = todoItemDTO.Priority
        };

        db.Todos.Add(todoItem);
        await db.SaveChangesAsync();

        return Created($"/todoitems/{todoItem.Id}", new TodoItemDTO(todoItem));
    });

// PUT - edit item by ID
    app.MapPut("/todoitems/{id}", async (int id, TodoItemDTO todoItemDTO, TodoDb db) =>
    {
        var todo = await db.Todos.FindAsync(id);

        if (todo == null) return NotFound();

        todo.Description = todoItemDTO.Description;
        todo.Completed = todoItemDTO.Completed;
        todo.Priority = todoItemDTO.Priority;

        await db.SaveChangesAsync();

        return NoContent();
    });

// DELETE - remove item by ID
    app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
    {
        if (await db.Todos.FindAsync(id) is Todo todo)
        {
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            return Ok();
        }

        return NoContent();
    });

#endregion

app.Run();