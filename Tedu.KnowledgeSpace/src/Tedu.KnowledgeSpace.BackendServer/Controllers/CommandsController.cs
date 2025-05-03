using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tedu.KnowledgeSpace.BackendServer.Data;
using Tedu.KnowledgeSpace.ViewModels.Systems;

namespace Tedu.KnowledgeSpace.BackendServer.Controllers;

public class CommandsController : BaseController
{
    private readonly ApplicationDbContext _context;

    public CommandsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<IActionResult> GetCommants()
    {
        var commands = _context.Commands;

        var commandVms = await commands.Select(u => new CommandVm()
        {
            Id = u.Id,
            Name = u.Name,
        }).ToListAsync();

        return Ok(commandVms);
    }
}
