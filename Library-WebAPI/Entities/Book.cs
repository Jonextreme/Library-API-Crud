namespace Library_WebAPI.Entities
{
    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; } = "";
        public int Year { get; private set; }
        public int MinimumAge { get; private set; }
        public int AuthorId { get; private set; }
        public Author Author { get; private set; } = null!;
        public ICollection<Genre> Genres { get; private set; } = new List<Genre>();
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

        public Book() { }
        public Book(string title, int year, int minimumAge)
        {
            SetTitle(title);
            SetYear(year);
            SetMinimumAge(minimumAge);
        }
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Book's title cannot be empty");
            if (title.Length > 50)
                throw new ArgumentException("Book's title cannot exceed 50 characters");

            Title = title;
        }
        public void SetYear(int year)
        {
            if(year > DateTime.Now.Year)
                throw new ArgumentException("Book's year cannot be later than the current year");
            if (year < 0)
                throw new ArgumentException("Book's year cannot be less than 0");

            Year = year;
        }
        public void SetMinimumAge(int minimumAge)
        {
            if (minimumAge > 150)
                throw new ArgumentException("Book's miniumAge cannot be greater than 150");
            if(minimumAge < 0)
                throw new ArgumentException("Book's minimumAge cannot be less than 0");

            MinimumAge = minimumAge;
        }
        public void SetAuthor(Author author)
        {
            if(author is null)
                throw new ArgumentNullException("Author cannot be null");
            Author = author;
            AuthorId = author.AuthorId;
        }
        public void AddGenre(Genre genre)
        {
            if (genre is null)
                throw new ArgumentNullException("Genre cannot be null");
            if(Genres.Any(x => x.GenreId == genre.GenreId))
                throw new ArgumentOutOfRangeException($"This genre already exist");
            Genres.Add(genre);
        }
        public void RemoveGenre(Genre genre)
        {
            if (genre is null)
                throw new ArgumentNullException("Genre cannot be null");
            if (!Genres.Any(x => x.GenreId == genre.GenreId))
                throw new ArgumentOutOfRangeException($"This genre {genre.GenreName} doesn't exist");
            Genres.Remove(genre);
        }
    }
}
