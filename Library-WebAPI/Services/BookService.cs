using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Exceptions;
using Library_WebAPI.Mappers;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BookListDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var bookListDTOs = books.Select(x => new BookListDTO
            {
                BookId = x.BookId,
                Title = x.Title
            }).ToList();
            return bookListDTOs;
        }
        public async Task<BookDetailsDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
                throw new NotFoundException($"There is no Book with this ID: {id}");

            var bookDetailsDTO = BookMapper.ToDetailsDTO(book);
            return bookDetailsDTO;
        }
        public async Task<BookDetailsDTO> CreateBookAsync(BookWriteDTO bookCreate)
        {
            var book = new Book(bookCreate.Title, bookCreate.Year, bookCreate.MinimumAge);
            var author = await _authorRepository.GetByIdAsync(bookCreate.AuthorId);
            var genres = await _genreRepository.GetByIdsAsync(bookCreate.GenresId);

            if (author is null)
                throw new NotFoundException($"There is no Author with this ID: {bookCreate.AuthorId}");

            if (genres.Count() != bookCreate.GenresId.Count)
                throw new NotFoundException($"One or more genres not found");

            foreach (var genre in genres)
            {
                book.AddGenre(genre);
            }
            book.SetAuthor(author);

            _bookRepository.Add(book);
            await _unitOfWork.SaveChangesAsync();

            var bookDetailsDTO = BookMapper.ToDetailsDTO(book);
            return bookDetailsDTO;
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
                throw new NotFoundException($"There is no Book with this ID: {id}");

            _bookRepository.Remove(book);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
 