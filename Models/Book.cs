using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class Book
    {
        public long Id { get; set; }
        [Required, StringLength(50)]
        public required string Title { get; set; }
        [Required]
        public required int Width { get; set; }
        [Required]
        public required int Height { get; set; }
        [Required, StringLength(50)]
        public required string Genre { get; set; }
        public long BooksSetId { get; set; }
        public BookSet? BookSet { get; set; }    

    }
}
