namespace Library_WebAPI.Entities
{
    public class Author
    {
        public int AuthorId { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Biography { get; private set; }
        public ICollection<Book> Books { get; private set; } = new List<Book>();
        public Author() { }
        public Author(string name, string? biography)
        {
            SetName(name);
            SetBiography(biography);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Author's name cannot be empty");
            if (name.Length > 80)
                throw new ArgumentException("Author's name cannot exceed 80 characters");

            Name = name;
        }
        public void SetBiography(string? biography)
        {
            Biography = biography;
        }
    }
}
