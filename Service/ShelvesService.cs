using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class ShelvesService : IShelvesService
    {
        private readonly ApplicationDbContext _context;
        public ShelvesService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Shelf>> GetShelves(long libraryId) => 
            await _context.Shelves
                .Where(x => x.LibraryId == libraryId)
                .ToListAsync();

        public string Shmuel()
        {
            return "Shmuel";
        }
    }
}
