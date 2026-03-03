using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.Enums;

namespace Library_WebAPI.DTOs.UserDTOs
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Permissions Permissions { get; set; }
        public List<LoanListDTO>? Loans { get; set; }
    }
}
