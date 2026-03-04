namespace Library_WebAPI.Repositories.Interfaces
{
    public interface IUnityOfWork
    {
        public Task<int> SaveChangesAsync();
    }
}
