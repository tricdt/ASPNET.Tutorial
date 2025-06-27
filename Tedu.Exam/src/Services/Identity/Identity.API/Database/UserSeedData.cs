using System;
using Identity.API.Extensions;
using Identity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Database;

public class UserSeedData : IDataSeeder<ApplicationDbContext>
{
    private readonly ILogger<UserSeedData> _logger;
    public UserSeedData(ILogger<UserSeedData> logger)
    {
        _logger = logger;
    }
    public async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Users.AnyAsync())
        {
            _logger.LogInformation("User data already exists");
            return;
        }
        var users = new List<ApplicationUser>
        {
            new ApplicationUser { FirstName = "admin", Email = "admin@example.com" },
            new ApplicationUser { LastName = "user1", Email = "user1@example.com" }
        };
        await context.Users.AddRangeAsync(users);
        _logger.LogInformation("Seeded {Count} users", users.Count);
    }
}