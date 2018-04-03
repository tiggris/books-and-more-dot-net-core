namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class BookInfo
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public State State { get; private set; }

        private BookInfo() { }
    }
}
