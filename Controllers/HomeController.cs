using library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using library.ViewModel;

namespace library.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult GetPerson()
        {
            PersonVM person = new()
            {
                Name = "enosh",
                Age = 34,
                ErrorMessage ="No way hoze!!"

            };
            return View(person);
        }

        public IActionResult Create()
        {
            return View(new PersonVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonVM person)
        {
            int a = 9;
            return Content("success");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
