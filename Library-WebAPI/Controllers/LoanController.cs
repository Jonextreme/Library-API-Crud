using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanListDTO>>> GetAllLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            if (!loans.Any())
                return NoContent();

            return Ok(loans);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LoanListDTO>> GetLoanById(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanListDTO>> CreateLoan(LoanWriteDTO loanCreate)
        {
            var loan = await _loanService.CreateLoanAsync(loanCreate);
            return CreatedAtAction(nameof(GetLoanById), new { id = loan.LoanId }, loan);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }
    }
}
