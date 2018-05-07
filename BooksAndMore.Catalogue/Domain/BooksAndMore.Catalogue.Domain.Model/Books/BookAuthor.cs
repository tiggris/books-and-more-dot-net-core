using BooksAndMore.Catalogue.Domain.Model.Authors;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class BookAuthor
    {
        public int BookId { get; private set; }
        public int AuthorId { get; private set; }
        public virtual Book Book { get; private set; }
        public virtual Author Author { get; private set; }

        protected BookAuthor() { }

        public BookAuthor(int bookId, int authorId)
        {
            BookId = bookId;
            AuthorId = authorId;
        }

        public BookAuthor(Book book, Author author)
        {
            Book = book;
            Author = author;
        }
    }
}
