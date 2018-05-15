namespace BooksAndMore.Catalogue.Application.Queries.TopBooksQuery
{
    public interface ITopBooksQuery
    {
        TopBooksList GetTopBooks(int booksCount);
    }
}
