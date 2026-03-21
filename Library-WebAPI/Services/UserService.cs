using Library_WebAPI.Data.Repositories.Interfaces;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Entities;
using Library_WebAPI.Exceptions;
using Library_WebAPI.Mappers;
using Library_WebAPI.Services.Interfaces;

namespace Library_WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserListDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var userListDTOs = users.Select(x => UserMapper.ToListDTO(x));
            return userListDTOs;
        }
        public async Task<UserDetailsDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
                throw new NotFoundException($"There is no User with this ID: {id}");

            var userDetailsDTO = UserMapper.ToDetailsDTO(user);
            return userDetailsDTO;
        }
        public async Task<UserDetailsDTO> CreateUserAsync(UserCreateDTO userCreate)
        {
            var user = new User(userCreate.Name, userCreate.Telephone, userCreate.Email, userCreate.Birthdate);

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();

            var userDetailsDTO = UserMapper.ToDetailsDTO(user);
            return userDetailsDTO;
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user is null)
                throw new NotFoundException($"There is no User with this ID: {id}");

            _userRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
