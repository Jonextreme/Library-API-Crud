namespace Library_WebAPI.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new();
        public int BookId { get; set; }
        public Book Book { get; set; } = new();
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
