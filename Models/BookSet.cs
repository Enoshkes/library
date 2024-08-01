using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class BookSet
    {
        public long Id { get; set; }
        [Required, StringLength(50)]
        public required string Name { get; set; }
        public long ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
        public List<Book> Books { get; set; } = [];

    }
}
