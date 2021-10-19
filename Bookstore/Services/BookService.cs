using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services {
    public class BookService : IBookService {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) {
            _repository = repository;
        }

        public async Task<IList<Book>> Get() {
            return await _repository.GetBooks().ToListAsync();
        }

        public async Task<Book> Get(int id) {
            return await _repository.GetBooks().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Create(Book book) {
            await _repository.Create(book);
        }

        public async Task Update(int id, Book book) {
            //  id == book.id
            if (id != book.Id) {
                return;
            }
            
            //  ensure the book exists
            var bookDb = await Get(id);

            if (bookDb == null) {
                return;
            }

            //  update
            bookDb.Description = book.Description;
            bookDb.Title = book.Title;
            bookDb.Price = book.Price;

            await _repository.Update(bookDb);
        }

        public async Task Delete(int id) {
            //  ensure the book exists
            var bookDb = await Get(id);

            if (bookDb == null) {
                return;
            }

            await _repository.Delete(bookDb);
        }
    }
}