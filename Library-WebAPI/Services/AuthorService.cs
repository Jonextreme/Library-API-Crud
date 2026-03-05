using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.AuthorDTOs;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnityOfWork _unitOfWork;
        public AuthorService(IAuthorRepository authorRepository, IUnityOfWork unityOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unityOfWork;
        }
        public Task<AuthorDetailsDTO> CreateAuthor(AuthorCreateDTO author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorListDTO>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDetailsDTO> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
