using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Repositories.Books
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        private BooksCatalogueContext _dataContext;

        public BooksRepository(BooksCatalogueContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetTopBooksWithReviews(int booksCount)
        {
            return _dataContext.Books
                .Include(book => book.Reviews)
                .OrderByDescending(book => book.Reviews.Select(review => review.Rating).DefaultIfEmpty(0).Average())
                .Take(booksCount)
                .ToList();
        }
    }
}
