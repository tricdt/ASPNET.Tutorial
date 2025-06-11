using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Tedu.TodoBlazor.Api.Entities;
using Tedu.TodoBlazor.Api.Enums;
using Task = System.Threading.Tasks.Task;
namespace Tedu.TodoBlazor.Api.Data;

public class TodoListDbContextSeed
{
    private static readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
    public static async Task SeedAsync(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TodoListDbContext>();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    PhoneNumber = "032132131",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
