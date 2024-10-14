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

        public async Task<TodoItem> CreateTodo(string id, string title)
        {
            var newTodo = new TodoItem { TodoId = id, Done = false, Title = title };

            _db.Todos.Attach(newTodo);
            await _db.SaveChangesAsync();

            return newTodo;
        }

        public async Task<TodoItem?> MarkTodoAsDone(string id)
        {
            var found = await _db.Todos.FirstOrDefaultAsync(todo => todo.TodoId == id);

            if (found == null)
            {
                return null;
            }

            found.Done = true;

            await _db.SaveChangesAsync();

            return found;
        }

    }
}
