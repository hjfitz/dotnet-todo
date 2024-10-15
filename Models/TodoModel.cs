using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{

    public class TodoItem
    {
        [Key]
        public string TodoId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public TodoItem(string todoId, string title, bool done)
        {
            TodoId = todoId;
            Title = title;
            Done = done;
        }

        public TodoItem()
        {
        }
    }

    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> Todos => Set<TodoItem>();

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

    }
}
