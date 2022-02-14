using System;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public PriorityEnum Priority { get; set; }
        public bool Completed { get; set; }

        public TodoItemDTO()
        {
        }

        public TodoItemDTO(Todo todoItem) =>
            (Id, Description, Completed, Priority, CreatedTime) = (todoItem.Id, todoItem.Description, todoItem.Completed, todoItem.Priority, DateTime.Now);
    }
}