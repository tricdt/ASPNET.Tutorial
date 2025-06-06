using System;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Identity.Data;
using DDD.Infra.CrossCutting.Identity.Models;
using DDD.Infra.CrossCutting.Identity.Models.AccountViewModels;
using DDD.Infra.CrossCutting.Identity.Services;
using k8s.KubeConfigModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DDD.Services.Api.Controllers.v1;

[ApiVersion("1.0")]
public class AccountController : ApiController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuthDbContext _dbContext;
    private readonly IUser _user;
    private readonly IJwtFactory _jwtFactory;
     private readonly ILogger _logger;
    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        AuthDbContext dbContext,
        IUser user,
        IJwtFactory jwtFactory,
        ILoggerFactory loggerFactory,
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator)
        : base(notifications, mediator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
        _user = user;
        _jwtFactory = jwtFactory;
        _logger = loggerFactory.CreateLogger<AccountController>();
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public IActionResult Login([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            //Log.Information("Invalid login attempt for user {Email}", model.Email);
            // NotifyModelStateErrors();
            // return Response();
            _logger.LogWarning("Invalid login attempt for user {Email}", model.Email);
        }
        _logger.LogInformation("Attempting to login user {Email}", model.Email);
        //Log.Information("Attempting to login user {Email}", model.Email);
        return Ok(new
        {
            Message = "Login successful",
            User = model.Email,
            Date = DateTime.UtcNow
        });
    }


    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new
        {
            Message = "Welcome to DDD Services API",
            Version = "1.0",
            Date = DateTime.UtcNow
        });
    }
}
