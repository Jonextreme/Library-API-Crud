using Library_WebAPI.DTOs.UserDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserListDTO>> GetAllUsersAsync();
        public Task<UserDetailsDTO> GetUserByIdAsync(int id);
        public Task<UserDetailsDTO> CreateUserAsync(UserWriteDTO userCreate);
        public Task DeleteUserAsync(int id);
    }
}
