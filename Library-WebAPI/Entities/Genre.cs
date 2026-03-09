namespace Library_WebAPI.Entities
{
    public class Genre
    {
        public int GenreId { get; private set; }
        public string GenreName { get; private set; } = "";
        public ICollection<Book> Books { get; private set; } = new List<Book>();

        public Genre() { }
        public Genre(string genreName)
        {
            SetGenreName(genreName);
        }
        public void SetGenreName(string genreName)
        {
            if(string.IsNullOrWhiteSpace(genreName))
                throw new ArgumentException("Genre's name cannot be empty");
            if (genreName.Length > 30)
                throw new ArgumentException("Genre's title cannot exceed 30 characters");

            GenreName = genreName;
        }
    }
}
