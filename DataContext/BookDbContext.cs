using Microsoft.EntityFrameworkCore;
using MVCBookMgtSystem.Models.Domain;

namespace MVCBookMgtSystem.DataContext
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {           
        }

        public DbSet<Book> Books { get; set; }   
    }
}
