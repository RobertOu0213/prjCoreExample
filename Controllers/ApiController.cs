using Microsoft.AspNetCore.Mvc;
using prjCoreExample.Models;
using prjCoreExample.ViewModel;
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



        public IActionResult CheckAccount(string name, string email)
        {
            if (name == "Jack" && email == "Jack@Jack.com")
            {
                return Content("此姓名和郵件已有人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (name == "Jack")
            {
                return Content("此姓名已有人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (email == "Jack@Jack.com")
            {
                return Content("此郵件已使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                return Content("此姓名和郵件無人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                return Content("此姓名無人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                return Content("此郵件無人使用", "text/html", System.Text.Encoding.UTF8);
            }

            return Content("請提供有效的姓名和郵件", "text/html", System.Text.Encoding.UTF8);



        }


        [HttpPost]
        public IActionResult CheckAccount([FromBody] CUserViewModel user)
        {
            if (user.Name == "Jack")
            {
                return Content("此姓名已有人使用", "text/html", System.Text.Encoding.UTF8);
            }

            if (user.Email == "Jack@Jack.com")
            {
                return Content("此郵件已使用", "text/html", System.Text.Encoding.UTF8);
            }

            return Content($"Hello! {user.Name}, {user.Age}歲了, 電子郵件是{user.Email}", "text/html", System.Text.Encoding.UTF8);

        }

    }


}
