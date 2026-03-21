using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Mappers
{
    public static class UserMapper
    {
        public static UserListDTO ToListDTO(User user)
        {
            var userListDTO = new UserListDTO
            {
                UserId = user.UserId,
                Name = user.Name
            };
            return userListDTO;
        }
        public static UserDetailsDTO ToDetailsDTO(User user)
        {
            var userDetailsDTO = new UserDetailsDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Telephone = user.Telephone,
                Email = user.Email,
                Birthdate = user.Birthdate,
                Loans = user.Loans?.Select(x => new LoanListDTO
                {
                    LoanId = x.LoanId,
                    User = new UserListDTO { UserId = x.UserId, Name = x.User.Name },
                    Book = new BookListDTO { BookId = x.BookId, Title = x.Book.Title },
                    BorrowedAt = x.BorrowedAt,
                    ReturnedAt = x.ReturnedAt
                }).ToList() ?? new List<LoanListDTO>(),
                Permissions = user.Permissions
            };
            return userDetailsDTO;
        }
    }
}
