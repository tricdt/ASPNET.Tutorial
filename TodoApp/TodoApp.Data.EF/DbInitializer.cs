using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TodoApp.Data.Entities;
using TodoApp.Data.Enums;

namespace TodoApp.Data.EF;

public class DbInitializer
{
    private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
    public async Task SeedAsync(AppDbContext context, ILogger<DbInitializer> logger)
    {
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
            user.PasswordHash = _passwordHasher.HashPassword(user, "123456");
            context.Users.Add(user);
            var user1 = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mrs",
                LastName = "B",
                Email = "user@gmail.com",
                PhoneNumber = "032132131",
                UserName = "user"
            };
            user1.PasswordHash = _passwordHasher.HashPassword(user1, "123456");
            context.Users.Add(user1);
        }

        if (!context.Todos.Any())
        {
            context.Todos.Add(new Entities.Todo()
            {
                Id = Guid.NewGuid(),
                Name = "Same tasks 1",
                CreatedDate = DateTime.Now,
                Priority = Priority.High,
                Status = Status.Open
            });
            context.Todos.Add(new Entities.Todo()
            {
                Id = Guid.NewGuid(),
                Name = "Same tasks 2",
                CreatedDate = DateTime.Now,
                Priority = Priority.High,
                Status = Status.Open
            });
        }

        await context.SaveChangesAsync();
    }
}
