using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookListDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            if (!books.Any())
                return NoContent();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDetailsDTO>> CreateBook(BookWriteDTO bookCreate)
        {
            var book = await _bookService.CreateBookAsync(bookCreate);
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
