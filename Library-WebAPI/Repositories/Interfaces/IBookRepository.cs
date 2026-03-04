using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public Book? GetById(int id);
        public Book Add(Book book);
        public Book Update(Book book);
        public Book Remove(Book book);
    }
}
