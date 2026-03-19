using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllAsync();
        public Task<Book?> GetByIdAsync(int id);
        public void Add(Book book);
        public void Remove(Book book);
    }
}
