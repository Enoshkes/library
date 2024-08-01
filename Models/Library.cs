using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    [Index (nameof(Genre), IsUnique = true)]
    public class Library
    {
        public long Id { get; set; }
        [Required, StringLength (50)]
        public required string Genre { get; set; }
        public List<Shelf> Shelf { get; set; } = [];
    }
}
