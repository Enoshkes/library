using library.Models;

namespace library.Service
{
    public interface ILibraryService
    {
        Task<Library> CreateLibrary(string genre);

        Task<List<Library>> GetAllLibraries();
    }
}
