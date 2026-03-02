using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;

namespace Library_WebAPI.DTOs.BookDTOs
{
    public class BookDetailsDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public int MinimumAge { get; set; }
        public AuthorListDTO Author { get; set; } = null!;
        public List<GenreListDTO> Genres { get; set; } = new();
        public List<LoanListDTO> Loans { get; set; } = new();
    }
}
