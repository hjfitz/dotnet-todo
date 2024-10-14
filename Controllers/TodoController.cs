using Microsoft.AspNetCore.Mvc;
using Todo.Services;

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

    }
}
