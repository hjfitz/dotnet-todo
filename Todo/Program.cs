using Todo.Models;
using Todo.Services;
using Todo.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Todo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddScoped<ITodoService, TodoService>();
	builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

	app.UseRouting();

	app.MapControllers();

	app.UseEndpoints(endpoints => 
	{
	    endpoints.MapControllers();
	});

        app.Run();

    }
}
