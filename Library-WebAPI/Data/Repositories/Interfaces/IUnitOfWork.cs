namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
    }
}
