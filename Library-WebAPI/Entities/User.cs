using Library_WebAPI.Enums;

namespace Library_WebAPI.Entities
{
    public class User
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = "";
        public string? Email { get; set; }
        public int Age { get; set; }
        public Permissions Permissions { get; set; }
        public ICollection<Loan>? Loans { get; set; }
    }
}
