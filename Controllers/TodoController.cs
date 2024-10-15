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

        [HttpGet("ping")]
        public IActionResult ping()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var allTodos = await _todoService.GetTodos();
            return Ok(allTodos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoItemDTO createTodoItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _todoService.CreateTodo(
                title: createTodoItemDto.Title
            );

            return Created();
        }

    }
}
