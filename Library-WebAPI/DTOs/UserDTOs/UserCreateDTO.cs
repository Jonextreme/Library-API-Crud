using Library_WebAPI.Enums;

namespace Library_WebAPI.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
