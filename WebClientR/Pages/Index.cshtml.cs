using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
        private HttpClient _http;

        [BindProperty(SupportsGet = true)] public List<TodoItemDTO> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITodoService service)
        {
            _service = service;
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _logger = logger;
            _http = new HttpClient(clientHandler);
        }

        private async Task GetItems()
        {
            Items = new();
            var items = await _http.GetFromJsonAsync<List<TodoItemDTO>>($"https://127.0.0.1:7237/todoitems");
            Items = items.OrderByDescending(x => x.Priority).ToList();
        }

        public async Task<IActionResult> OnGet()
        {
            await GetItems();
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
            await _http.DeleteAsync($"https://127.0.0.1:7237/todoitems/{todoItem.Id}");
            return await this.OnGet();
        }

        public async Task<IActionResult> OnPostEditModal(TodoItemDTO todoItem)
        {
            switch (todoItem.Id)
            {
                case < 1:
                    await _http.PostAsJsonAsync($"https://127.0.0.1:7237/todoitems", todoItem);
                    break;
                case > 0:
                    await _http.PutAsJsonAsync($"https://127.0.0.1:7237/todoitems/{todoItem.Id}", todoItem);
                    break;
            }

            return await OnGet();
        }
    }
}