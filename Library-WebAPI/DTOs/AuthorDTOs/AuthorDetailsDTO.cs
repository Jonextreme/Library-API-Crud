using Library_WebAPI.DTOs.BookDTOs;

namespace Library_WebAPI.DTOs.AuthorDTOs
{
    public class AuthorDetailsDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = "";
        public string? Biography { get; set; }
        public List<BookListDTO> Books { get; set; } = new();
    }
}
