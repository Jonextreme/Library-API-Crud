using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreListDTO>> GetAllGenres();
        public Task<GenreDetailsDTO?> GetGenreById(int id);
        public Task<GenreDetailsDTO> CreateGenre(GenreCreateDTO genre);
        public Task DeleteGenre(int id);
    }
}
