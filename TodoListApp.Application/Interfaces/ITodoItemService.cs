using TodoListApp.Domain.Entities;

namespace TodoListApp.Application.Interfaces
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAllByListIdAsync(int listId);
        Task<TodoItem> GetByIdAsync(int id);
        Task CreateAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(int id);
    }
}
