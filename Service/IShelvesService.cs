using library.Models;

namespace library.Service
{
    public interface IShelvesService
    {
        Task<IEnumerable<Shelf>> GetShelves(long libraryId);

        string Shmuel();
    }
}
