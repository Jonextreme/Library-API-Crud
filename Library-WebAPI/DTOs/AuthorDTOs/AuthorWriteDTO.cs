using System.ComponentModel.DataAnnotations;

namespace Library_WebAPI.DTOs.AuthorDTOs
{
    public class AuthorWriteDTO
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = "";
        public string? Biography { get; set; }
    }
}
