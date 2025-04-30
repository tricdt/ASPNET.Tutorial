using System;
using Microsoft.AspNetCore.Mvc;

namespace Tedu.KnowledgeSpace.BackendServer.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}