using Todo.Services;
using Todo.Models;

namespace Todo.Tests.Fixtures;

public class TodoServiceFixture : ITodoService
{
    private List<TodoItem> _todoItems = new List<TodoItem> {
    new TodoItem { TodoId = "a", Title = "mock todo", Done = false },
    };

    public Task<TodoItem?> FindTodoById(string id)
    {
        if (id == "found")
        {
            return Task.FromResult<TodoItem?>(
            new TodoItem { TodoId = id, Title = "mock todo", Done = false }
            );
        }

        return Task.FromResult<TodoItem?>(null);
    }

    public Task DeleteTodoById(string id)
    {
        return Task.CompletedTask;
    }

    public Task<TodoItem> CreateTodo(string title)
    {
        var newItem = new TodoItem { TodoId = "testid", Title = title, Done = false };
        return Task.FromResult(newItem);
    }

    public Task<TodoItem> UpdateTodo(TodoItem todo, string? newTitle, bool? newDone)
    {
        return Task.FromResult(todo);
    }

    public Task<List<TodoItem>> GetTodos()
    {
        return Task.FromResult(_todoItems);
    }
}
