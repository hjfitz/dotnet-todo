using Microsoft.AspNetCore.Mvc;
using Todo.Controllers;
using Todo.Models;
using Todo.Models.DTO;
using Todo.Tests.Fixtures;

namespace Todo.Tests
{

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

            Assert.IsType<List<TodoItem>>(okResult.Value);
        }

        [Fact]
        public async Task Test_GetTodo_ReturnsFoundTodo()
        {

            var result = await _todoController.GetTodo("found");

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<TodoItem>(okResult.Value);
        }

        [Fact]
        public async Task Test_GetTodo_ReturnsNotFoud()
        {
            var result = await _todoController.GetTodo("notfound");

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Test_CreateTodo_ReturnsBadRequestForInvalidPayload()
        {
            var failingPayload = new CreateTodoItemDTO { Title = "failed" };

            _todoController.ModelState.AddModelError("Title", "Title is required");

            var result = await _todoController.CreateTodo(failingPayload);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            _todoController.ModelState.Remove("Title");
        }

        [Fact]
        public async Task Test_CreateTodo_ReturnsOkWithCreatedTodo()
        {
            var payload = new CreateTodoItemDTO { Title = "passed" };

            var result = await _todoController.CreateTodo(payload);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<TodoItem>(okResult.Value);
        }

        [Fact]
        public async Task Test_UpdateTodo_ReturnsNotFoundForMissingTodo()
        {
            var payload = new UpdateTodoItemDTO { Title = "not found" };

            var result = await _todoController.UpdateTodo("not found", payload);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task Test_UpdateTodo_ReturnsOkWhenFoundAndUpdated()
        {
            var payload = new UpdateTodoItemDTO { Title = "not found" };

            var result = await _todoController.UpdateTodo("found", payload);

            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Test_DeleteTodo_ReturnsNotFoundForMissingTodo()
        {
            var result = await _todoController.DeleteTodo("not found");

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Test_DeleteTodo_ReturnsOkWhenFoundAndUpdated()
        {
            var result = await _todoController.DeleteTodo("found");

            var okResult = Assert.IsType<OkResult>(result);
        }



    }
}
