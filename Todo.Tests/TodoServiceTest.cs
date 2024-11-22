using Microsoft.EntityFrameworkCore;
using Todo.Services;
using Todo.Models;

namespace Todo.Tests
{

    public class TodoServiceTest
    {
        public TodoService _todoService;

        public TodoServiceTest()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                   .UseInMemoryDatabase(databaseName: "TestDb")
                   .Options;

            var context = new TodoContext(options);

	    SetupMockRecords(context);

	    _todoService = new TodoService(context);
        }

	public static void SetupMockRecords(TodoContext context) 
	{
	    context.Todos.Add(new TodoItem { Title = "mock 1", Done = false, TodoId = "1" });
	    context.Todos.Add(new TodoItem { Title = "mock 2", Done = false, TodoId = "2" });
	    context.Todos.Add(new TodoItem { Title = "mock 3", Done = false, TodoId = "3" });
	}

    }
}
