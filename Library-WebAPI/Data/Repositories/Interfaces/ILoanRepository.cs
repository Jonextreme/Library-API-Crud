using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public Task<IEnumerable<Loan>> GetAllAsync();
        public Task<Loan?> GetByIdAsync(int id);
        public void Add(Loan loan);
        public void Remove(Loan loan);
    }
}
