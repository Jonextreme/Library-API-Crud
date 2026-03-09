namespace Library_WebAPI.Entities
{
    public class Loan
    {
        public int LoanId { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; } = null!;
        public int BookId { get; private set; }
        public Book Book { get; private set; } = null!;
        public DateTime BorrowedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }
        public Loan()
        {
            BorrowedAt = DateTime.Now;
        }
        public Loan(User user, Book book) : base()
        {
            SetUser(user);
            SetBook(book);
        }
        public void SetUser(User user)
        {
            if(user is null)
                throw new ArgumentNullException("User can't be null");
            User = user;
            UserId = user.UserId;
        }
        public void SetBook(Book book)
        {
            if (book is null)
                throw new ArgumentNullException("Book can't be null");
            Book = book;
            BookId = book.BookId;
        }
        public void Returned()
        {
            ReturnedAt = DateTime.Now;
        }
    }
}
