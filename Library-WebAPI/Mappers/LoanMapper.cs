using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Mappers
{
    public static class LoanMapper
    {
        public static LoanListDTO ToListDTO(Loan loan)
        {
            var loanListDTO = new LoanListDTO
            {
                LoanId = loan.LoanId,
                User = new UserListDTO
                {
                    UserId = loan.UserId,
                    Name = loan.User.Name
                },
                Book = new BookListDTO
                {
                    BookId = loan.BookId,
                    Title = loan.Book.Title
                },
            };
            return loanListDTO;
        }
    }
}
