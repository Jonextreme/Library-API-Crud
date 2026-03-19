using Library_WebAPI.DTOs.BookDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookListDTO>> GetAllBooks();
        public Task<BookDetailsDTO> GetBookById(int id);
        public Task<BookDetailsDTO> CreateBook(BookCreateDTO book);
        public Task DeleteBook(int id);
    }
}
