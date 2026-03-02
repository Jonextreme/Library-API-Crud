using Library_WebAPI.DTOs.BookDTOs;

namespace Library_WebAPI.DTOs.GenreDTOs
{
    public class GenreDetailsDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = "";
        public List<BookListDTO> Books { get; set; } = new();
    }
}
