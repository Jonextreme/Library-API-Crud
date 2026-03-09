using Library_WebAPI.Enums;

namespace Library_WebAPI.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; } = "";
        public string Telephone { get; private set; } = "";
        public string? Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public Permissions Permissions { get; private set; }
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

        public User() { }
        public User(string name, string telephone, string? email, DateTime birthDate)
        {
            SetName(name);
            SetTelephone(telephone);
            SetEmail(email);
            SetBirthDate(birthDate);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User's name cannot be empty");
            if(name.Length > 80)
                throw new ArgumentException("User's name cannot exceed 80 characters");

            Name = name;
        }
        public void SetTelephone(string telephone)
        {
            if (string.IsNullOrWhiteSpace(telephone))
                throw new ArgumentException("User's telephone cannot be empty");
            if (telephone.Length > 16)
                throw new ArgumentException("User's telephone cannot exceed 16 characters");

            Telephone = telephone;
        }
        public void SetEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            if (email.Length > 100)
                throw new ArgumentException("User's email cannot exceed 100 characters");

            Email = email;
        }
        public void SetBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
                throw new ArgumentException("User's date of birth cannot be later than the current date.");

            Birthdate = birthDate;
        }
    }
}
