using Library_WebAPI.Entities;

namespace Library_WebAPI.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public IEnumerable<Loan> GetAll();
        public Loan GetById(int id);
        public Loan Add(Loan loan);
        public void Update(Loan loan);
        public void Remove(Loan loan);
    }
}
