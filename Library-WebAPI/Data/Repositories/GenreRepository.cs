using Library_WebAPI.Data.Context;
using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _appDbContext;
        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Genre>> GetAll() => await _appDbContext.Genres.AsNoTracking().ToListAsync();
        public async Task<Genre?> GetById(int id) => await _appDbContext.Genres.FindAsync(id);
        public void Add(Genre genre) => _appDbContext.Add(genre);
        public void Remove(Genre genre) => _appDbContext.Remove(genre);
    }
}
