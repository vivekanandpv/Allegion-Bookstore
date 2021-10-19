using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.Services {
    public interface IBookService {
        Task<IList<Book>> Get();
        Task<Book> Get(int id);
        Task Create(Book book);
        Task Update(int id, Book book);
        Task Delete(int id);
    }
}