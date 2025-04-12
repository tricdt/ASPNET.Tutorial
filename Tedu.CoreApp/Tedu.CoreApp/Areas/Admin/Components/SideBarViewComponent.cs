using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tedu.CoreApp.Application.Systems.Functions;
using Tedu.CoreApp.Application.Systems.Functions.Dtos;
using Tedu.CoreApp.Utilities.Constants;

namespace Tedu.CoreApp.Areas.Admin.Components;

public class SideBarViewComponent : ViewComponent
{
    private readonly IFunctionService _functionService;

    public SideBarViewComponent(IFunctionService functionService)
    {
        _functionService = functionService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var roles = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == CommonConstants.UserClaim.Roles);
        List<FunctionViewModel> functions;
        if (roles != null && roles.Value.Split(";").Contains(CommonConstants.AppRole.Admin))
            functions = await _functionService.GetAll(string.Empty);
        else
            functions = await _functionService.GetAllWithPermission(User.Identity.Name);
        return View(functions);
    }
}
