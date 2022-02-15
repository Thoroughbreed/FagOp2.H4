using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebAPI.DTO;

namespace WebClientR.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private HttpClient _http;
        
        [BindProperty(SupportsGet = true)]
        public List<TodoItemDTO> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            HttpClientHandler clientHandler = new ();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _logger = logger;
            _http = new HttpClient(clientHandler);
        }

        private async Task GetItems()
        {
            Items = new();
            Items = await _http.GetFromJsonAsync<List<TodoItemDTO>>($"https://127.0.0.1:7237/todoitems");
        }

        public async  Task<IActionResult> OnGet()
        {
            await GetItems();
            return Page();
        }
    }
}