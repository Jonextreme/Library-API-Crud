using Library_WebAPI.Enums;

namespace Library_WebAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Permissions Permissions { get; set; }
        public ICollection<Loan>? Loans { get; set; }
    }
}
