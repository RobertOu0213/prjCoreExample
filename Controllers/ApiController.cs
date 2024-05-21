using Microsoft.AspNetCore.Mvc;
using prjCoreExample.Models;
using System.Threading;

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
            Thread.Sleep(5000);
            return Content("哈囉", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Index()
        {

            //var cities = _context.Addresses.Select(r => r.City).Distinct();
            //return Json(cities);

            var cities = _context.Addresses
               .GroupBy(r => r.City)
               .Select(g => new { Id = g.FirstOrDefault().Id, City = g.Key });

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

        public IActionResult Register(int? id, string name = "Jack", int age = 20 )
        {
            return Content($"Hello {name}, you are {age} years old, you are {id}", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult CheckAccount(string name, string email, string age)
        {
            if(name == "Jack")
            {
                return Content("登入成功", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("登入失敗", "text/html", System.Text.Encoding.UTF8);
            }
        }

    }
}
