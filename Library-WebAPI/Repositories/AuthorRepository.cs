using System.Threading.Tasks;
using Library_WebAPI.Context;
using Library_WebAPI.Entities;
using Library_WebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Author>> GetAll() => await _appDbContext.Authors.AsNoTracking().ToListAsync();

        public async Task<Author?> GetById(int id) => await _appDbContext.Authors.FindAsync(id);
        public void Add(Author author) => _appDbContext.Authors.Add(author);
        public void Remove(Author author) => _appDbContext.Authors.Remove(author);
    }
}
