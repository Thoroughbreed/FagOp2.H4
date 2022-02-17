using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebAPI.DAL;
using WebAPI.DTO;
using WebAPI.Models;
using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddCors();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
string domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auto0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("R", policy => policy.RequireAuthenticatedUser().RequireClaim("permissions", "todo:read"));
    options.AddPolicy("E", policy => policy.RequireAuthenticatedUser().RequireClaim("permissions", "todo:write"));
    options.AddPolicy("D", policy => policy.RequireAuthenticatedUser().RequireClaim("permissions", "todo:delete"));
});
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
    o.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

#region API Endpoints

// GET - default, all non-completed
app.MapGet("/todoitems", async (TodoDb db) =>
{
    var items = await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync();
    return items.Where(x => x.Completed == false);
}).RequireAuthorization("R");

// GET - all items
app.MapGet("/todoitems/all", async (TodoDb db) =>
    await db.Todos.Select(x => new TodoItemDTO(x)).ToListAsync()).RequireAuthorization("R");

// GET - item by ID
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id) is Todo todo ? Ok(new TodoItemDTO(todo)) : NotFound()).RequireAuthorization("R");

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
}).RequireAuthorization("E");

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
}).RequireAuthorization("E");

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
}).RequireAuthorization("D");

#endregion

app.Run();

public abstract class HasScopeRequirement : IAuthorizationRequirement
{
    public string Issuer { get; }
    public string Scope { get; }

    protected HasScopeRequirement(string scope, string issuer)
    {
        Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        // If user does not have the scope claim, get out of here
        if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
            return Task.CompletedTask;

        // Split the scopes string into an array
        var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

        // Succeed if the scope array contains the required scope
        if (scopes.Any(s => s == requirement.Scope))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}