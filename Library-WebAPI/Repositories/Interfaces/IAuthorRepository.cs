using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<Author> GetAll();
        public Author? GetById(int id);
        public Author Add(Author author);
        public void Update(Author author);
        public void Remove(Author author);
    }
}
