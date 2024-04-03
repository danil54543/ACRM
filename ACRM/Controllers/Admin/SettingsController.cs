using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACRM.Controllers.Admin
{
    [Route("admin/settings/[action]")]
    [Authorize(Roles = "admin")]
    public class SettingsController : Controller
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
