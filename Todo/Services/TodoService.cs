using Todo.Models;
using Microsoft.EntityFrameworkCore;
namespace Todo.Services
{

    public class TodoService : ITodoService
    {

        private TodoContext _db { get; set; }

        public TodoService(TodoContext db)
        {
            _db = db;
        }

        public async Task DeleteTodoById(string id)
        {
            var found = await _db.Todos.FindAsync(id);

            if (found == null)
            {
                return;
            }

            _db.Todos.Remove(found);

            await _db.SaveChangesAsync();

        }

        public async Task<TodoItem?> FindTodoById(string id)
        {
            var found = await _db.Todos.FirstOrDefaultAsync(todo => todo.TodoId == id);

            return found;
        }

        public async Task<TodoItem> CreateTodo(string title)
        {
            var todoId = Guid.NewGuid().ToString();
            var newTodo = new TodoItem
            {
                TodoId = todoId,
                Done = false,
                Title = title
            };

            _db.Todos.Add(newTodo);
            await _db.SaveChangesAsync();

            return newTodo;
        }

        public async Task<TodoItem> UpdateTodo(TodoItem todo, string? newTitle, bool? newDone )
        {

	    todo.Title = newTitle ?? todo.Title;
	    todo.Done = newDone ?? todo.Done;

            _db.Todos.Attach(todo);

            await _db.SaveChangesAsync();

            return todo;
        }

        public async Task<List<TodoItem>> GetTodos()
        {
            var found = await _db.Todos.ToListAsync();
            return found;
        }

    }
}
