using Library_WebAPI.Context;
using Library_WebAPI.Entities;
using Library_WebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<User>> GetAll() => await _appDbContext.Users.AsNoTracking().ToListAsync();
        public async Task<User?> GetById(int id) => await _appDbContext.Users.FindAsync(id);
        public void Add(User user) => _appDbContext.Add(user);
        public void Remove(User user) => _appDbContext.Remove(user);
    }
}
