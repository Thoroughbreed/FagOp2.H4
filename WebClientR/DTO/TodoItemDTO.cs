using System;

namespace WebClientR.DTO
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

        public enum PriorityEnum
        {
            Low,
            Normal,
            High
        }
    }
}