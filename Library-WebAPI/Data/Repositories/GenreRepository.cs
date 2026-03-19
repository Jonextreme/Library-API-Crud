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
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _appDbContext.Genres.AsNoTracking().ToListAsync();
        }
        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _appDbContext.Genres.Include(x => x.Books).FirstOrDefaultAsync(x => x.GenreId == id);
        }
        public async Task<IEnumerable<Genre>> GetByIdsAsync(IEnumerable<int> genresIds)
        {
            return await _appDbContext.Genres.Where(x => genresIds.Distinct().Contains(x.GenreId)).AsNoTracking().ToListAsync();
        }
        public void Add(Genre genre)
        {
            _appDbContext.Genres.Add(genre);
        }
        public void Remove(Genre genre)
        {
            _appDbContext.Genres.Remove(genre);
        }
    }
}
