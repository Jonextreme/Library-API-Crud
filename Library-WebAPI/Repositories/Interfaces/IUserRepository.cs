using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User Add(User user);
        public void Update(User user);
        public void Remove(User user);
    }
}
