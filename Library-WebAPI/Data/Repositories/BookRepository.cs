using Library_WebAPI.Data.Context;
using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Book>> GetAll() => await _appDbContext.Books.AsNoTracking().ToListAsync();
        public async Task<Book?> GetById(int id) => await _appDbContext.Books.FindAsync(id);
        public void Add(Book book) => _appDbContext.Add(book);
        public void Remove(Book book) => _appDbContext.Remove(book);
    }
}
