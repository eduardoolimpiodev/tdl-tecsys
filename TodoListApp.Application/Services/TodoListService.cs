using Microsoft.EntityFrameworkCore;
using TodoListApp.Application.Interfaces;
using TodoListApp.Domain.Entities;
using TodoListApp.Infrastructure;

namespace TodoListApp.Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext _context;

        public TodoListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoList>> GetAllAsync()
        {
            return await _context.TodoLists.Include(t => t.Items).ToListAsync();
        }

        public async Task<TodoList> GetByIdAsync(int id)
        {
            return await _context.TodoLists.Include(t => t.Items)
                                           .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(TodoList todoList)
        {
            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoList todoList)
        {
            _context.TodoLists.Update(todoList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
