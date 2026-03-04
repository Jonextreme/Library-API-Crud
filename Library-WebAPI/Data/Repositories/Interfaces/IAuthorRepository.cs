using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<IEnumerable<Author>> GetAll();
        public Task<Author?> GetById(int id);
        public void Add(Author author);
        public void Remove(Author author);
    }
}
