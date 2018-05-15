using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooksByAuthor(string author);
        IEnumerable<Book> GetTopBooksWithReviews(int booksCount);     
    }
}