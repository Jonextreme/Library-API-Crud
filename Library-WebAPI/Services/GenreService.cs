using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.GenreDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Exceptions;
using Library_WebAPI.Mappers;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GenreListDTO>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();

            var genreListDTOs = genres.Select(x => GenreMapper.ToListDTO(x));
            return genreListDTOs;
        }
        public async Task<GenreDetailsDTO> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre is null)
                throw new NotFoundException($"There is no Genre with this ID: {id}");

            var genreDetailsDTO = GenreMapper.ToDetailsDTO(genre);
            return genreDetailsDTO;
        }
        public async Task<GenreDetailsDTO> CreateGenreAsync(GenreCreateDTO genreCreate)
        {
            var genre = new Genre(genreCreate.GenreName);

            _genreRepository.Add(genre);
            await _unitOfWork.SaveChangesAsync();

            var genreDetailsDTO = GenreMapper.ToDetailsDTO(genre);
            return genreDetailsDTO;
        }
        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if(genre is null)
                throw new NotFoundException($"There is no Genre with this ID: {id}");

            _genreRepository.Remove(genre);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
