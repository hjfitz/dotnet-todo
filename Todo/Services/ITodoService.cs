using Todo.Models;

namespace Todo.Services;

public interface ITodoService
{
    public Task<TodoItem?> FindTodoById(string id);

    public Task DeleteTodoById(string id);

    public Task<TodoItem> CreateTodo(string title);

    public Task<TodoItem> UpdateTodo(TodoItem todo, string? newTitle, bool? newDone);

    public Task<List<TodoItem>> GetTodos();
}
