using BooksAndMore.Catalogue.Domain.Model.Books;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Application.Queries.BooksQuery
{
    public class BooksQuery : IBooksQuery
    {
        private readonly Domain.Common.Data.IQueryProvider _queryProvider;

        public BooksQuery(Domain.Common.Data.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        public IList<BooksListItem> GetBooks(int pageIndex, int pageSize)
        {
            return _queryProvider.Query<Book>()
                 .OrderBy(book => book.Title)
                 .Skip(pageIndex * pageSize)
                 .Take(pageSize)
                 .Select(book => new BooksListItem
                 {
                     Id = book.Id,
                     Isbn = book.Isbn,
                     Title = book.Title,
                     IsIllustrated = book.IsIllustrated,
                     AverageRating = book.AverageRating,
                     Authors = book.BookAuthors.Select(bookAuthor => new BooksListItem.BookAuthor
                     {
                         Id = bookAuthor.Author.Id,
                         Name = bookAuthor.Author.FullName
                     }).ToList(),
                     Publisher = book.Publisher != null ? new BooksListItem.BookPublisher
                     {
                         Id = book.Publisher.Id,
                         Name = book.Publisher.Name,
                         Address = $"{book.Publisher.Address.Street} {book.Publisher.Address.Building}/{book.Publisher.Address.Apartment}, {book.Publisher.Address.ZipCode} {book.Publisher.Address.City} {book.Publisher.Address.Country}"
                     } : null
                 })
                 .ToList();
        }
    }
}
