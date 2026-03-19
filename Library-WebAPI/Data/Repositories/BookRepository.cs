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
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _appDbContext.Books.AsNoTracking().ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _appDbContext.Books.Include(x => x.Author).Include(x => x.Genres).Include(x => x.Loans).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.BookId == id);
        }
        public void Add(Book book) 
        {
            _appDbContext.Books.Add(book);
        } 
        public void Remove(Book book)
        {
            _appDbContext.Books.Remove(book);
        }
    }
}
