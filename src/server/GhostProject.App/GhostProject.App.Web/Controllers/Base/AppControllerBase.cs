using Microsoft.AspNetCore.Mvc;

namespace GhostProject.App.Web.Controllers.Base
{
    public abstract class AppControllerBase : ControllerBase
    {
        protected string UserIdentity => HttpContext.User?.Identity?.Name;

    }
}
