namespace Library_WebAPI.DTOs.BookDTOs
{
    public class BookCreateDTO
    {
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public int MinimumAge { get; set; }
        public int AuthorId { get; set; }
        public List<int> GenresId { get; set; } = new();
    }
}
