using Library_WebAPI.DTOs.BookDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookListDTO>> GetAllBooksAsync();
        public Task<BookDetailsDTO> GetBookByIdAsync(int id);
        public Task<BookDetailsDTO> CreateBookAsync(BookCreateDTO bookCreate);
        public Task DeleteBookAsync(int id);
    }
}
