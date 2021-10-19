using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL {
    public class BookstoreContext : DbContext {
        public BookstoreContext(DbContextOptions<BookstoreContext> options): base(options) {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}