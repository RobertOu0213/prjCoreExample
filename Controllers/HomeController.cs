using Microsoft.AspNetCore.Mvc;
using prjCoreExample.Models;
using System.Diagnostics;


namespace prjCoreExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext _context;
 


        public HomeController(ILogger<HomeController> logger, MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Categories.Where(r => r.CategoryId == 1);
            return View(products);   
        }

        public IActionResult First()
        {
           
            return View();
        }
        public IActionResult Address() {
         return View();
        }

        public IActionResult json()
        {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}