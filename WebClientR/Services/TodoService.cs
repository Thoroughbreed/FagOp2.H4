using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebClientR.DTO;

namespace WebClientR.Services
{
    public class TodoService : ITodoService
    {
        private HttpClient _client;
        public TodoService()
        {
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _client = new HttpClient(clientHandler);
        }
        public async Task<List<TodoItemDTO>> GetItems()
        {
            var items = await _client.GetFromJsonAsync<List<TodoItemDTO>>(AppConstants.BaseAdress);
            return items != null ? items.OrderByDescending(x => x.Priority).ToList() : new List<TodoItemDTO>();
        }

        public async Task<bool> CreateItem(TodoItemDTO todoItem)
        {
            var responseMessage = await _client.PostAsJsonAsync($"{AppConstants.BaseAdress}", todoItem);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> EditItem(TodoItemDTO todoItem)
        {
            var responseMessage = await _client.PutAsJsonAsync($"{AppConstants.BaseAdress}/{todoItem.Id}", todoItem);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var responseMessage = await _client.DeleteAsync($"{AppConstants.BaseAdress}/{id}");
            return responseMessage.IsSuccessStatusCode;
        }
    }
}