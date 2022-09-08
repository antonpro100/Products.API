using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        internal Guid UserId => !User.Identity.IsAuthenticated 
            ? Guid.Empty 
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    }
}
