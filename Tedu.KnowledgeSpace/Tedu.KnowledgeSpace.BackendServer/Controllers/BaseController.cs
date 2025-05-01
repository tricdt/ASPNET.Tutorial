using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tedu.KnowledgeSpace.BackendServer.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize("Bearer")]
public class BaseController : ControllerBase
{

}
