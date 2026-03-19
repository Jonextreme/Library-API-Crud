using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface ILoanService
    {
        public Task<IEnumerable<LoanListDTO>> GetAllLoansAsync();
        public Task<LoanListDTO> GetLoanByIdAsync(int id);
        public Task<LoanListDTO> CreateLoanAsync(LoanCreateDTO loan);
        public Task DeleteLoanAsync(int id);
    }
}
