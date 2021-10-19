using System.Linq;
using System.Threading.Tasks;
using Bookstore.DAL;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories {
    public class BookRepository : IBookRepository {
        private readonly BookstoreContext _context;

        public BookRepository(BookstoreContext context) {
            _context = context;
        }

        public IQueryable<Book> GetBooks() {
            return _context.Books;
        }

        public async Task Create(Book book) {
            await _context.Books.AddAsync(book);
            await Save();
        }

        public async Task Update(Book book) {
            _context.Entry(book).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Book book) {
            _context.Entry(book).State = EntityState.Deleted;
            await Save();
        }

        private async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}