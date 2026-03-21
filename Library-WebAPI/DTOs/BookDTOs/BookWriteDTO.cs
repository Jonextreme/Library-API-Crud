using System.ComponentModel.DataAnnotations;

namespace Library_WebAPI.DTOs.BookDTOs
{
    public class BookWriteDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = "";
        [Required]
        [Range(0, 9999)]
        public int Year { get; set; }
        [Required]
        [Range(0, 140)]
        public int MinimumAge { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public List<int> GenresId { get; set; } = new();
    }
}
