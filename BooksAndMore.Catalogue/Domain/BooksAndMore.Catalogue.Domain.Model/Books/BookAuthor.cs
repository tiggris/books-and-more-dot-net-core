using BooksAndMore.Catalogue.Domain.Model.Authors;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class BookAuthor
    {
        public int BookId { get; private set; }
        public int AuthorId { get; private set; }
        public Book Book { get; private set; }
        public Author Author { get; private set; }
    }
}
