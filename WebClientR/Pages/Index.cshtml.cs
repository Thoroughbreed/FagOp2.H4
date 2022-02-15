using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using WebClientR.DTO;
using WebClientR.Services;

namespace WebClientR.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITodoService _service;

        [BindProperty(SupportsGet = true)] public List<TodoItemDTO> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITodoService service)
        {
            _service = service;
            _logger = logger;
        }


        public async Task<IActionResult> OnGet()
        {
            Items = await _service.GetItems();
            return Page();
        }

        public PartialViewResult OnGetDeleteModal(int id, string desc, TodoItemDTO.PriorityEnum prio)
        {
            return new PartialViewResult
            {
                ViewName = "_DeleteModal",
                ViewData = new ViewDataDictionary<TodoItemDTO>(ViewData,
                    new TodoItemDTO { Id = id, Description = desc, Priority = prio })
            };
        }

        public PartialViewResult OnGetEditModal(int id, string desc, TodoItemDTO.PriorityEnum prio)
        {
            return new PartialViewResult
            {
                ViewName = "_EditModal",
                ViewData = new ViewDataDictionary<TodoItemDTO>(ViewData,
                    new TodoItemDTO { Id = id, Description = desc, Priority = prio })
            };
        }

        public async Task<IActionResult> OnPostDeleteModal(TodoItemDTO todoItem)
        {
            var response = await _service.DeleteItem(todoItem.Id);
            if (response) return await OnGet();
            return NotFound();
        }

        public async Task<IActionResult> OnPostEditModal(TodoItemDTO todoItem)
        {
            bool response;
            switch (todoItem.Id)
            {
                case < 1:
                    response = await _service.CreateItem(todoItem);
                    if (response) return await OnGet();
                    return NotFound();
                case > 0:
                    response = await _service.EditItem(todoItem);
                    if (response) return await OnGet();
                    return NotFound();
            }
        }
    }
}