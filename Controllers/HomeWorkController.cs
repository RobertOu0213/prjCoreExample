using Microsoft.AspNetCore.Mvc;

namespace prjCoreExample.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
          public IActionResult CheckAccount()
        {
            return View();
        }

        public IActionResult Spots()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult test()
        {
            return View();
        }

    }
}
