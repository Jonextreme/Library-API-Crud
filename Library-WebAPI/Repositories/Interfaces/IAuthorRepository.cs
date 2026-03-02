using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<Author> GetAllAuthors();
        public Author AddAuthors();
    }
}
