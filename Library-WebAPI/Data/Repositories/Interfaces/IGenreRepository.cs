using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<Genre>> GetAllAsync();
        public Task<Genre?> GetByIdAsync(int id);
        public Task<IEnumerable<Genre>> GetByIdsAsync();
        public void Add(Genre genre);
        public void Remove(Genre genre);
    }
}
