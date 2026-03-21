using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreListDTO>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            if (!genres.Any())
                return NoContent();

            return Ok(genres);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDetailsDTO>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<GenreDetailsDTO>> CreateGenre(GenreWriteDTO genreCreate)
        {
            var genre = await _genreService.CreateGenreAsync(genreCreate);
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.GenreId }, genre);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}
