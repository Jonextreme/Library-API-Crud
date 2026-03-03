using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.DTOs.LoanDTOs
{
    public class LoanListDTO
    {
        public int LoanId { get; set; }
        public UserListDTO User { get; set; } = null!;
        public BookListDTO Book { get; set; } = null!;
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
