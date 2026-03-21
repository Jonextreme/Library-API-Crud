using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Exceptions;
using Library_WebAPI.Mappers;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoanService(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LoanListDTO>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllAsync();

            var loanListDTOs = loans.Select(x => LoanMapper.ToListDTO(x));
            return loanListDTOs;
        }
        public async Task<LoanListDTO> GetLoanByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan is null)
                throw new NotFoundException($"There is no Loan with this ID: {id}");

            var loanListDTO = LoanMapper.ToListDTO(loan);
            return loanListDTO;
        }
        public async Task<LoanListDTO> CreateLoanAsync(LoanWriteDTO loanCreate)
        {
            var loan = new Loan();
            var user = await _userRepository.GetByIdAsync(loanCreate.UserId);
            var book = await _bookRepository.GetByIdAsync(loanCreate.BookId);

            if (user is null)
                throw new NotFoundException($"There is no User with this ID: {loanCreate.UserId}");
            if (book is null)
                throw new NotFoundException($"There is no Book with this ID: {loanCreate.BookId}");

            loan.SetUser(user);
            loan.SetBook(book);

            _loanRepository.Add(loan);
            await _unitOfWork.SaveChangesAsync();

            var loanListDTO = LoanMapper.ToListDTO(loan);
            return loanListDTO;
        }
        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if(loan is null)
                throw new NotFoundException($"There is no Loan with this ID: {id}");

            _loanRepository.Remove(loan);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
