using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<Genre>> GetAll();
        public Task<Genre?> GetById(int id);
        public void Add(Genre genre);
        public void Remove(Genre genre);
    }
}
