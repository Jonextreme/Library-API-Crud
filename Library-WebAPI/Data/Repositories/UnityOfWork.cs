using Library_WebAPI.Data.Context;
using Library_WebAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Data.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnityOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<int> SaveChangesAsync() => _appDbContext.SaveChangesAsync();
    }
}
