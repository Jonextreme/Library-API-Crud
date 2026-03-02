namespace Library_WebAPI.DTOs.AuthorDTOs
{
    public class AuthorCreateDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = "";
        public string? Biography { get; set; }
    }
}
