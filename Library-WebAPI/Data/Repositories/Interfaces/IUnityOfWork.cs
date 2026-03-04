namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface IUnityOfWork
    {
        public Task<int> SaveChangesAsync();
    }
}
