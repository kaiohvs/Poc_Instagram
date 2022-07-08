using Microsoft.AspNetCore.Mvc;

namespace Poc2._0.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
