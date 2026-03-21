using System.ComponentModel.DataAnnotations;

namespace Library_WebAPI.DTOs.LoanDTOs
{
    public class LoanWriteDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
