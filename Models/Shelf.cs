using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class Shelf
    {
        public long Id { get; set; }
        [Required]
        public required int Height { get; set; }
        [Required]
        public required int Width { get; set; }
        public long LibraryId { get; set; }
        public Library? Library { get; set; }
        public List<BookSet> BookSets { get; set; } = [];
    }
}
