using Microsoft.AspNetCore.Mvc;

namespace multi_saas_platform_api.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
