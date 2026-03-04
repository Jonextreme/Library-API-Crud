using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAll();
        public Task<Book?> GetById(int id);
        public void Add(Book book);
        public void Remove(Book book);
    }
}
