using System.Threading.Tasks;
using Library_WebAPI.Data.Context;
using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _appDbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<Author?> GetById(int id)
        {
            return await _appDbContext.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.AuthorId == id);
        }
        public void Add(Author author)
        {
            _appDbContext.Authors.Add(author);
        }
        public void Remove(Author author)
        {
            _appDbContext.Authors.Remove(author);
        }
    }
}
