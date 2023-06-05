using Microsoft.AspNetCore.Mvc;

namespace ASP.NET___fiorello_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
