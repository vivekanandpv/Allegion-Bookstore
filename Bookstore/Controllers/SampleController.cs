using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SampleController: ControllerBase {
        
        [HttpGet("{id:regex(^[[ABC]]{{1}}[[0-9]]{{4}}$)}")]
        public IActionResult Greet(string id) {
            return Ok($"Good afternoon from controller: {id}");
        }
    }
}