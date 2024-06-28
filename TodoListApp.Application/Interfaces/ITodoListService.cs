using TodoListApp.Domain.Entities;

namespace TodoListApp.Application.Interfaces
{
    public interface ITodoListService
    {
        Task<IEnumerable<TodoList>> GetAllAsync();
        Task<TodoList> GetByIdAsync(int id);
        Task CreateAsync(TodoList todoList);
        Task UpdateAsync(TodoList todoList);
        Task DeleteAsync(int id);
    }
}
