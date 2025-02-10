using KonyvtarAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static KonyvtarAPI.Models.DTOs.BookDTO;

namespace KonyvtarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(CreateBookDTO createBookDTO)
        {
            var currentBook = new Book
            {
                Title = createBookDTO.Title,
                Author = createBookDTO.Author,
                PublishedYear = createBookDTO.PublishedYear,
                Genre = createBookDTO.Genre,
                Price = createBookDTO.Price,
            };

            _context.Books.Add(currentBook);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = currentBook.Id }, currentBook);
        }
    }
}
