

namespace Library_WebAPI.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public int MinimumAge { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = new();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Loan>? Loans { get; set; }
    }
}
