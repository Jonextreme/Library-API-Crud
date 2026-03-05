using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;

namespace Library_WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserListDTO>> GetAllUsers();
        public Task<UserDetailsDTO> GetUserById(int id);
        public Task<UserDetailsDTO> CreateUser(UserCreateDTO user);
        public Task DeleteUser(int id);
    }
}
