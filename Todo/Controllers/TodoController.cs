using Microsoft.AspNetCore.Mvc;
using Todo.Services;
using Todo.Models.DTO;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTodos()
        {
            var allTodos = await _todoService.GetTodos();
            return Ok(allTodos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(string id)
        {
            var found = await _todoService.FindTodoById(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoItemDTO createTodoItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var createdTodo = await _todoService.CreateTodo(
                title: createTodoItemDto.Title
            );

            return Ok(createdTodo);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ToggleTodoDoneState(
            string id,
            [FromBody] UpdateTodoItemDTO updateTodoItemDTO
        )
        {
            var found = await _todoService.FindTodoById(id);

            if (found == null)
            {
                return NotFound();
            }

            var updatedTodo = await _todoService.UpdateTodo(
                found,
                updateTodoItemDTO.Title,
                updateTodoItemDTO.Done
            );

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            var found = await _todoService.FindTodoById(id);

            if (found == null)
            {
                return NotFound();
            }

            await _todoService.DeleteTodoById(id);

            return Ok();
        }


    }
}
