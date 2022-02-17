using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using WebClientR.DTO;

namespace WebClientR.Services
{
    public class TodoService : ITodoService
    {
        private HttpClient _client;
        private IHttpContextAccessor _httpContextAccessor;
        
        public TodoService(IHttpContextAccessor httpContextAccessor, HttpClient client)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }
        public async Task<List<TodoItemDTO>> GetItems()
        {
            await InitializeHttpClient();
            var items = await _client.GetFromJsonAsync<List<TodoItemDTO>>(AppConstants.BaseAdress);
            return items != null ? items.OrderByDescending(x => x.Priority).ToList() : new List<TodoItemDTO>();
        }

        public async Task<bool> CreateItem(TodoItemDTO todoItem)
        {
            await InitializeHttpClient();
            var responseMessage = await _client.PostAsJsonAsync($"{AppConstants.BaseAdress}", todoItem);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> EditItem(TodoItemDTO todoItem)
        {
            await InitializeHttpClient();
            var responseMessage = await _client.PutAsJsonAsync($"{AppConstants.BaseAdress}/{todoItem.Id}", todoItem);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItem(int id)
        {
            await InitializeHttpClient();
            var responseMessage = await _client.DeleteAsync($"{AppConstants.BaseAdress}/{id}");
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task InitializeHttpClient()
        {
            var BearerToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
        }
    }
}