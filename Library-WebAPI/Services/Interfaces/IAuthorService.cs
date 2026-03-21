using Library_WebAPI.DTOs.AuthorDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorListDTO>> GetAllAuthorsAsync();
        public Task<AuthorDetailsDTO> GetAuthorByIdAsync(int id);
        public Task<AuthorDetailsDTO> CreateAuthorAsync(AuthorWriteDTO authorCreate);
        public Task DeleteAuthorAsync(int id);
    }
}
