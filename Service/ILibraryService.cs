using library.Models;
using library.ViewModel;

namespace library.Service
{
    public interface ILibraryService
    {
        Task<Library?> FindById(long libraryId);
        Task<Library> CreateLibrary(string genre);

        Task<Library> EditLibrary(long libraryId, LibraryVM libraryVM);

        Task<List<Library>> GetAllLibraries();
    }
}
