using System;

namespace WebAPI.Models
{
    public enum PriorityEnum
    {
        Low,
        Normal,
        High
    }
    public class Todo
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public PriorityEnum Priority { get; set; }
        public bool Completed { get; set; }
        public string? Secret { get; set; }
    }
}