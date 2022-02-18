using System.Collections.Generic;
using System.Threading.Tasks;
using WebClientR.DTO;

namespace WebClientR.Services
{
    public interface ITodoService
    {
        public Task<List<TodoItemDTO>> GetItems();
        public Task<bool>  CreateItem(TodoItemDTO todoItem);
        public Task<bool>  EditItem(TodoItemDTO todoItem);
        public Task<bool> DeleteItem(int id);
        public Task<string> InitializeHttpClient();

    }
}