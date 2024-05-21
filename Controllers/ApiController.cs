using Microsoft.AspNetCore.Mvc;
using prjCoreExample.Models;

namespace prjCoreExample.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult City()
        {
            return Content("<h1>哈囉</h1>", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Index()
        {

            var cities = _context.Addresses.Select(r => r.City).Distinct();
            var cityList = (from r in _context.Addresses
                            select r.City).Distinct();
            return Json(cities);
        }

        public IActionResult Cat(int? id)
        {
            Member? member = _context.Members.Find(id);
            if(member != null)
            {
                byte[] img = member.FileData;
                if(img != null)
                {
                    return File(img, "image/jpeg");
                }
              
                   
                
            }
            return NotFound();
        }

    }
}
