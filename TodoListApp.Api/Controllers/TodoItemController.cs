using Microsoft.AspNetCore.Mvc;
using TodoListApp.Application.Interfaces;
using TodoListApp.Domain.Entities;

namespace TodoListApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("list/{listId}")]
        public async Task<IActionResult> GetAllByListId(int listId)
        {
            var todoItems = await _todoItemService.GetAllByListIdAsync(listId);
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoItem = await _todoItemService.GetByIdAsync(id);
            if (todoItem == null) return NotFound();
            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoItem todoItem)
        {
            if (todoItem == null) return BadRequest();

            await _todoItemService.CreateAsync(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id) return BadRequest();

            await _todoItemService.UpdateAsync(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
