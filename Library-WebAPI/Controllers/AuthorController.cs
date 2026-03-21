using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorListDTO>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            if (!authors.Any())
                return NoContent();

            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthorDetailsDTO>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDetailsDTO>> CreateAuthor(AuthorCreateDTO authorCreate)
        {
            var author = await _authorService.CreateAuthorAsync(authorCreate);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorId }, author);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
