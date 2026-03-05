using System.ComponentModel.DataAnnotations;
using Library_WebAPI.Enums;

namespace Library_WebAPI.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = "";
        [Required]
        [MaxLength(16)]
        public string Telephone { get; set; } = "";
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
