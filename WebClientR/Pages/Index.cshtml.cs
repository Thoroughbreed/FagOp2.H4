using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebAPI.DTO;

namespace WebClientR.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<TodoItemDTO> _items = new ();
        private HttpClient _http = new ();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            _items = await _http.GetFromJsonAsync<List<TodoItemDTO>>($"https://127.0.0.1:7237/todoitems");
        }
    }
}