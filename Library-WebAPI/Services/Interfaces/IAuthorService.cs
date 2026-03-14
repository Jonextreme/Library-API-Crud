using Library_WebAPI.DTOs.AuthorDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorListDTO>> GetAllAuthors();
        public Task<AuthorDetailsDTO?> GetAuthorById(int id);
        public Task<AuthorDetailsDTO> CreateAuthor(AuthorCreateDTO author);
        public Task DeleteAuthor(int id);
    }
}
