using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Todo.Models
{

    public class TodoItem
    {
        // cool, this is implicitely set to the key
        // because the field has "id"
        // could use data annotations (eg [Key])
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
