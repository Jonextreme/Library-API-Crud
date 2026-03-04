using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User?> GetById(int id);
        public void Add(User user);
        public void Remove(User user);
    }
}
