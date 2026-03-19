using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorListDTO ToListDTO(Author author)
        {
            var authorListDTO = new AuthorListDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name
            };
            return authorListDTO;
        }
        public static AuthorDetailsDTO ToDetailsDTO(Author author)
        {
            var authorDetailsDTO = new AuthorDetailsDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Biography = author.Biography,
                Books = author.Books.Select(x => new BookListDTO
                {
                    BookId = x.BookId,
                    Title = x.Title
                }).ToList() ?? new List<BookListDTO>()
            };
            return authorDetailsDTO;
        }
    }
}
