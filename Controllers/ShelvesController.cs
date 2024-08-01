using library.Service;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly IShelvesService _service;

        public ShelvesController(IShelvesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(long libraryId)
        {
            ViewBag.LibraryId = libraryId;

            return View(await _service.GetShelves(libraryId));
        }

        public IActionResult Create(long libraryId)
        {
            ViewBag.LibraryId = libraryId;  

            return View();
        }

        [HttpPost]
        public IActionResult Create(int width, int height, long libraryId)
        {
            return RedirectToAction("Index");
        }
    }
}
