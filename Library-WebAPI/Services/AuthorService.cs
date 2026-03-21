using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.DTOs.BookDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Exceptions;
using Library_WebAPI.Mappers;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AuthorListDTO>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            var authorListDTOs = authors.Select(x => AuthorMapper.ToListDTO(x));
            return authorListDTOs;
        }

        public async Task<AuthorDetailsDTO> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author is null)
                throw new NotFoundException($"There is no Author with this ID: {id}");

            var authorDetailsDTO = AuthorMapper.ToDetailsDTO(author);
            return authorDetailsDTO;
        }
        public async Task<AuthorDetailsDTO> CreateAuthorAsync(AuthorCreateDTO authorCreate)
        {
            var author = new Author(authorCreate.Name, authorCreate.Biography);

            _authorRepository.Add(author);
            await _unitOfWork.SaveChangesAsync();

            var authorDetailsDTO = AuthorMapper.ToDetailsDTO(author);
            return authorDetailsDTO;
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if(author is null)
                throw new NotFoundException($"There is no Author with this ID: {id}");

            _authorRepository.Remove(author);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
