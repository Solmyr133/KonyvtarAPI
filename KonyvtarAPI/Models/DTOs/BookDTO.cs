namespace KonyvtarAPI.Models.DTOs
{
    public class BookDTO
    {
        public class CreateBookDTO
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int PublishedYear { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
        }
    }
}
