using Microsoft.AspNetCore.Mvc;
using Todo.Controllers;
using Todo.Models;
using Todo.Tests.Fixtures;

namespace Todo.Tests;

public class TodoControllerTest
{

    public TodoController _todoController;

    public TodoControllerTest()
    {
        var mockedService = new TodoServiceFixture();
        _todoController = new TodoController(mockedService);
    }

    [Fact]
    public async Task Test_GetTodos_ReturnsTodos()
    {
        var result = await _todoController.GetTodos();

        var okResult = Assert.IsType<OkObjectResult>(result);

        Assert.Equal(200, okResult.StatusCode);

        var responseBody = Assert.IsType<List<TodoItem>>(okResult.Value);

    }

    [Fact]
    public async Task Test_GetTodo_ReturnsFoundTodo()
    {
    }

}
