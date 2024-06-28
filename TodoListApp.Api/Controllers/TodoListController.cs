using Microsoft.AspNetCore.Mvc;
using TodoListApp.Application.Interfaces;
using TodoListApp.Domain.Entities;

namespace TodoListApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todoLists = await _todoListService.GetAllAsync();
            return Ok(todoLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoList = await _todoListService.GetByIdAsync(id);
            if (todoList == null) return NotFound();
            return Ok(todoList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoList todoList)
        {
            if (todoList == null) return BadRequest();

            await _todoListService.CreateAsync(todoList);
            return CreatedAtAction(nameof(GetById), new { id = todoList.Id }, todoList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoList todoList)
        {
            if (id != todoList.Id) return BadRequest();

            await _todoListService.UpdateAsync(todoList);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoListService.DeleteAsync(id);
            return NoContent();
        }
    }
}
