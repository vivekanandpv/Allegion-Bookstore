using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook() {
            return Ok(await _bookService.Get());
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id) {
            return Ok(await _bookService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book) {
            await _bookService.Create(book);
            return Ok();
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(Book book, int id) {
            await _bookService.Update(id, book);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id) {
            await _bookService.Delete(id);
            return Ok();
        }
    }
}