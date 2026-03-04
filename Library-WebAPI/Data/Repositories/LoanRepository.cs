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
        public async Task<IEnumerable<Loan>> GetAll() => await _appDbContext.Loans.AsNoTracking().ToListAsync();
        public async Task<Loan?> GetById(int id) => await _appDbContext.Loans.FindAsync(id);
        public void Add(Loan loan) => _appDbContext.Add(loan);
        public void Remove(Loan loan) => _appDbContext.Remove(loan);
    }
}
