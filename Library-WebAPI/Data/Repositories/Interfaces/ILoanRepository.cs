using Library_WebAPI.Entities;

namespace Library_WebAPI.Data.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public Task<IEnumerable<Loan>> GetAll();
        public Task<Loan?> GetById(int id);
        public void Add(Loan loan);
        public void Remove(Loan loan);
    }
}
