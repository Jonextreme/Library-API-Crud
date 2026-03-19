using Library_WebAPI.Data.Context;
using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _appDbContext.Loans.AsNoTracking().ToListAsync();
        }
        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _appDbContext.Loans.Include(x => x.User).Include(x => x.Book).FirstOrDefaultAsync(x => x.LoanId == id);
        }
        public void Add(Loan loan)
        {
            _appDbContext.Loans.Add(loan);
        }
        public void Remove(Loan loan)
        {
            _appDbContext.Loans.Remove(loan);
        }
    }
}
