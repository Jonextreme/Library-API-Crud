using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Entities;

namespace Library_WebAPI.Mappers
{
    public static class GenreMapper
    {
        public static GenreListDTO ToListDTO(Genre genre)
        {
            var genreListDTO = new GenreListDTO
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            };
            return genreListDTO;
        }
        public static GenreDetailsDTO ToDetailsDTO(Genre genre)
        {
            var genreDetailsDTO = new GenreDetailsDTO
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName,
                Books = genre.Books.Select(x => new BookListDTO
                {
                    BookId = x.BookId,
                    Title = x.Title
                }).ToList()
            };
            return genreDetailsDTO;
        }
    }
}
