using System;
using Microsoft.EntityFrameworkCore;
using Tedu.TodoBlazor.Api.Data;
using Tedu.TodoBlazor.Api.Entities;

namespace Tedu.TodoBlazor.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoListDbContext _context;

    public UserRepository(TodoListDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetUserList()
    {
        return await _context.Users.ToListAsync();
    }
}
