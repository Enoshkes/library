using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, 
            IConfiguration configuration
        ) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection")
            );
        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookSet> BookSets { get; set; }
        public DbSet<Book> Books   { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Shelf)
                .WithOne(s => s.Library)
                .HasForeignKey(s => s.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shelf>()
                .HasMany(s => s.BookSets)
                .WithOne(b => b.Shelf)
                .HasForeignKey(b => b.ShelfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookSet>()
                .HasMany(b => b.Books)
                .WithOne(b => b.BookSet)
                .HasForeignKey(b => b.BooksSetId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
