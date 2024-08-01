
using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class LibraryService : ILibraryService
    {

        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Library> CreateLibrary(string genre)
        {
            Library? res  = await _context.Libraries
                .FirstOrDefaultAsync(x => x.Genre == genre);

            if (res != null) 
            {
                throw new Exception(
                    $"Library by the genre {genre} is already exists"
                );
            }
            Library library = new () { Genre = genre };

            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<List<Library>> GetAllLibraries() => 
            await _context.Libraries.ToListAsync();
        
    }
}
