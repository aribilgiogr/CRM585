using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
    }
}
