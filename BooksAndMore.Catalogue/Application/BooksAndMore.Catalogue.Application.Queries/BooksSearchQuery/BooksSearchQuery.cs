using BooksAndMore.Catalogue.Domain.Model.Books;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery
{
    public class BooksSearchQuery : IBooksSearchQuery
    {
        private readonly Domain.Common.Data.IQueryProvider _queryProvider;

        public BooksSearchQuery(Domain.Common.Data.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        public IList<BooksListItem> SearchBooks(string searchTerm)
        {
            return _queryProvider.Query<Book>()
                .Where(book => 
                    book.Title.Contains(searchTerm) || 
                    book.BookAuthors.Any(bookAuthor => bookAuthor.Author.FullName.Contains(searchTerm)))
                .Select(book => new BooksListItem {
                    Id = book.Id,
                    Isbn = book.Isbn,
                    Title = book.Title,
                    // ToList()!
                    Authors = string.Join(", ", book.BookAuthors.Select(bookAuthor => bookAuthor.Author.FullName).ToList())
                })
                .ToList();
        }
    }
}
