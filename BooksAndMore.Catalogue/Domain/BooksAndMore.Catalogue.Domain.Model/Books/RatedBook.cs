namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class RatedBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AverageRating { get; set; }
    }
}
