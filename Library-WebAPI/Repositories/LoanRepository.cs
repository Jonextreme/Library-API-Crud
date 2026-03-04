using Library_WebAPI.Context;
using Library_WebAPI.Entities;
using Library_WebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPI.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Loan>> GetAll() => await _appDbContext.Loans.AsNoTracking().ToListAsync();
        public async Task<Loan?> GetById(int id) => await _appDbContext.Loans.FindAsync(id);
        public void Add(Loan loan) => _appDbContext.Add(loan);
        public void Remove(Loan loan) => _appDbContext.Remove(loan);
    }
}
