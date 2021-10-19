using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.Repositories {
    public interface IBookRepository {
        IQueryable<Book> GetBooks();
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}