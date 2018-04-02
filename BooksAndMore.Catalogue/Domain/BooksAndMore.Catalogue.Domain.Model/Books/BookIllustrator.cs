using BooksAndMore.Catalogue.Domain.Model.Authors;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class BookIllustrator
    {
        public int BookId { get; private set; }
        public int IllustratorId { get; private set; }
        public IllustratedBook Book { get; private set; }
        public Illustrator Illustrator { get; private set; }

        private BookIllustrator() { }

        public BookIllustrator(int bookId, int illustratorId)
        {
            BookId = bookId;
            IllustratorId = illustratorId;
        }

        public BookIllustrator(IllustratedBook book, Illustrator illustrator)
        {
            Book = book;
            Illustrator = illustrator;
        }
    }
}
