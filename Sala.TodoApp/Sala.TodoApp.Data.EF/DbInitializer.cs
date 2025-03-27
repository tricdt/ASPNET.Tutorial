using System;
using Microsoft.AspNetCore.Identity;
using Sala.TodoApp.Data.Entities;
using Sala.TodoApp.Data.Enums;

namespace Sala.TodoApp.Data.EF;

public class DbInitializer
{
    private readonly AppDbContext _context;
    private UserManager<User> _userManager;
    private RoleManager<Role> _roleManager;
    public DbInitializer(AppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task Seed()
    {
        if (!_roleManager.Roles.Any())
        {
            await _roleManager.CreateAsync(new Role()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Top manager"
            });
            await _roleManager.CreateAsync(new Role()
            {
                Name = "Staff",
                NormalizedName = "Staff",
                Description = "Staff"
            });
            await _roleManager.CreateAsync(new Role()
            {
                Name = "Customer",
                NormalizedName = "Customer",
                Description = "Customer"
            });
        }

        if (!_userManager.Users.Any())
        {
            await _userManager.CreateAsync(new User()
            {
                UserName = "admin",
                FirstName = "Administrator",
                Email = "admin@gmail.com",
                LastName = "",

            }, "123654$");
            var user = await _userManager.FindByNameAsync("admin");
            await _userManager.AddToRoleAsync(user, "Admin");
        }
        if (!_context.Todos.Any())
        {
            _context.Todos.AddRange(new List<Todo>(){
                new Todo(){Id = Guid.NewGuid() ,CreatedDate = DateTime.Now, Name = "Công việc 1", Priority = Priority.Medium, Status = Status.Resolved},
                new Todo(){Id = Guid.NewGuid() ,CreatedDate = DateTime.Now, Name = "Công việc 2", Priority = Priority.Medium, Status = Status.Resolved}
            });
        }
        await _context.SaveChangesAsync();
    }
}