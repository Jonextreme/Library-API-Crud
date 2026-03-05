using System.ComponentModel.DataAnnotations;

namespace Library_WebAPI.DTOs.GenreDTOs
{
    public class GenreCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string GenreName { get; set; } = "";
    }
}
