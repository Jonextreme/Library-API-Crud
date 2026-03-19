using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Mappers
{
    public static class BookMapper
    {
        public static BookListDTO ToListDTO(Book book)
        {
            var bookListDTO = new BookListDTO
            {
                BookId = book.BookId,
                Title = book.Title
            };
            return bookListDTO;
        }
        public static BookDetailsDTO ToDetailsDTO(Book book)
        {
            var bookDetailsDTO = new BookDetailsDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                Year = book.Year,
                MinimumAge = book.MinimumAge,
                Author = new AuthorListDTO { AuthorId = book.AuthorId, Name = book.Author.Name },
                Genres = book.Genres.Select(x => new GenreListDTO
                {
                    GenreId = x.GenreId,
                    GenreName = x.GenreName
                }).ToList(),
                Loans = book.Loans?.Select(x => new LoanListDTO
                {
                    LoanId = x.LoanId,
                    User = new UserListDTO { UserId = x.UserId, Name = x.User.Name },
                    Book = new BookListDTO { BookId = x.BookId, Title = x.Book.Title },
                    BorrowedAt = x.BorrowedAt,
                    ReturnedAt = x.ReturnedAt
                }).ToList() ?? new List<LoanListDTO>()
            };
            return bookDetailsDTO;
        }
    }
}
