using BooksAndMore.Catalogue.Domain.Model.Books;
using System.Linq;

namespace BooksAndMore.Catalogue.Application.Queries.TopBooksQuery
{
    public class TopBooksQuery : ITopBooksQuery
    {
        private readonly Domain.Common.Data.IQueryProvider _queryProvider;

        public TopBooksQuery(Domain.Common.Data.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        public TopBooksList GetTopBooks(int booksCount)
        {
            var booksQuery = _queryProvider.Query<Book>();
            var books = booksQuery
                .Select(book => new TopBooksListItem
                {
                    Id = book.Id,
                    Title = book.Title,
                    Rating = book.Reviews
                        .Select(review => (decimal?)review.Rating)
                        .Average()
                })
                .OrderByDescending(book => book.Rating)
                .Take(booksCount)
                .ToList();
           
            return new TopBooksList
            {
                Books = books,
                BooksCount = booksQuery.Count()
            };
        }
    }
}