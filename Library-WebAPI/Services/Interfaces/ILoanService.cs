using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface ILoanService
    {
        public Task<IEnumerable<LoanListDTO>> GetAllLoans();
        public Task<LoanListDTO> GetLoanById(int id);
        public Task<LoanListDTO> CreateLoan(LoanCreateDTO loan);
        public Task DeleteLoan(int id);
    }
}
