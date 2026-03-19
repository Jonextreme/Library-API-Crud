using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreListDTO>> GetAllGenresAsync();
        public Task<GenreDetailsDTO> GetGenreByIdAsync(int id);
        public Task<GenreDetailsDTO> CreateGenreAsync(GenreCreateDTO genreCreate);
        public Task DeleteGenreAsync(int id);
    }
}
