using library.Models;
using library.Service;
using library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
            IEnumerable<Shelf> shelves = [
                new () { LibraryId = 1, Height = 9, Width = 78 }
            ];
            var a = shelves.Select(x => x.LibraryId).FirstOrDefault();
        }
        public async Task<IActionResult> Index() => 
            View(await _libraryService.GetAllLibraries());
        

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(long libraryId)
        {
            Library? byId = await _libraryService.FindById(libraryId);

            if (byId == null) {  return RedirectToAction("Index"); }

            ViewBag.LibraryId = libraryId;

            return View(new LibraryVM());

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
