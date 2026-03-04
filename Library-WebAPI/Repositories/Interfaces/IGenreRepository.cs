using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetAll();
        public Genre? GetById(int id);
        public Genre Add(Genre genre);
        public void Update(Genre genre);
        public void Delete(Genre genre);
    }
}
