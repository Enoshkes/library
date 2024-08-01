using library.Service;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public async Task<IActionResult> Index() => 
            View(await _libraryService.GetAllLibraries());
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string genre)
        {
            try
            {
                await _libraryService.CreateLibrary(genre);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View();
            }      
        }
    }
}
