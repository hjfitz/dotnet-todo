using Todo.Models;

namespace Todo.Services;

public interface ITodoService
{
    public Task<TodoItem?> FindTodoById(string id);

    public Task DeleteTodoById(string id);

    public Task<TodoItem> CreateTodo(string id, string title);

    public Task<TodoItem?> MarkTodoAsDone(string id);
}