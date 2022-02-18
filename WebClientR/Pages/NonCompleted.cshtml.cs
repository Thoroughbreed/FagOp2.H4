using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using WebClientR.DTO;
using WebClientR.Services;

namespace WebClientR.Pages
{
    [Authorize]
    public class NonCompleted : PageModel
    {
        private readonly ITodoService _service;

        [BindProperty(SupportsGet = true)] 
        public TodoItemDTO TodoItem { get; set; }
        [BindProperty(SupportsGet = true)] 
        public List<TodoItemDTO> Items { get; set; }
        public bool CanDelete { get; set; }
        public bool CanWrite { get; set; }
        public bool CanRead { get; set; }
        

        public NonCompleted(ITodoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            switch (User.Claims.FirstOrDefault(c => c.Type == "https://tved.it/accessToken/roles")!.Value)
            {
                case "User":
                    CanRead = true;
                    break;
                case "Sudo":
                    CanRead = true;
                    CanWrite = true;
                    break;
                case "Admin":
                    CanRead = true;
                    CanWrite = true;
                    CanDelete = true;
                    break;
            }
            
            if (CanRead) 
                Items = await _service.GetItems();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteModal(TodoItemDTO todoItem)
        {
            var response = await _service.DeleteItem(todoItem.Id);
            if (response) return RedirectToPage("./NonCompleted");
            return NotFound();
        }

        public async Task<IActionResult> OnPostEditModal(TodoItemDTO todoItem)
        {
            bool response;
            ModelState.ClearValidationState(nameof(todoItem));
            TryValidateModel(nameof(todoItem));
            if (!ModelState.IsValid)
                return await OnGet();
            switch (TodoItem.Id)
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