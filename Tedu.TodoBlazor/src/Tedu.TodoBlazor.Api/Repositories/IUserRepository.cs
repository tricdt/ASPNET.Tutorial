using System;
using Tedu.TodoBlazor.Api.Entities;

namespace Tedu.TodoBlazor.Api.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUserList();
}
