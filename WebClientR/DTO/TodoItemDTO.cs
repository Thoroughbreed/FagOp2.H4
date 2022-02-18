using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebClientR.DTO
{
    public class TodoItemDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        [Required]
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