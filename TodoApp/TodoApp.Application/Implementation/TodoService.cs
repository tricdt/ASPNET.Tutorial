using System;
using TodoApp.Data.Entities;
using TodoApp.Infrastructure.Interfaces;

namespace TodoApp.Application.Implementation;

public class TodoService
{
    private readonly IRepository<Todo, Guid> repository;
    private readonly IUnitOfWork unitOfWork;

    public TodoService(IRepository<Todo, Guid> repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }
}
