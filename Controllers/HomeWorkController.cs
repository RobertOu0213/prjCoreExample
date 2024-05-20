using Microsoft.AspNetCore.Mvc;

namespace prjCoreExample.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
