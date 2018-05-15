using BooksAndMore.Catalogue.Application.Queries.BooksQuery;
using BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery;
using BooksAndMore.Catalogue.Application.Queries.TopBooksQuery;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data;
using BooksAndMore.Catalogue.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Web.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly IBooksQuery _booksQuery;
        private readonly ITopBooksQuery _topBooksQuery;
        private readonly IBooksSearchQuery _booksSearchQuery;
        private readonly BooksCatalogueContext _context;

        public BooksController(IBooksQuery booksQuery, ITopBooksQuery topBooksQuery, IBooksSearchQuery booksSearchQuery, BooksCatalogueContext context)
        {
            _booksQuery = booksQuery;
            _topBooksQuery = topBooksQuery;
            _booksSearchQuery = booksSearchQuery;
            _context = context;
        }

        // GET api/books/top10
        [HttpGet("top10")]
        public TopBooksList GetTop10()
        {
            return _topBooksQuery.GetTopBooks(10);
        }

        // GET api/books/search
        [HttpGet("search")]
        public IList<BooksSearchListItem> Search(string term)
        {
            return _booksSearchQuery.SearchBooks(term);
        }

        // GET api/books
        [HttpGet]
        public IEnumerable<BooksListItem> Get(int pageIndex = 0, int pageSize = 5)
        {
            return _booksQuery.GetBooks(pageIndex, pageSize);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var book = _context.Books.Find(id);
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                IsIllustrated = book.IsIllustrated,
                Publisher = new BookModel.PublisherModel
                {
                    Id = book.Publisher.Id,
                    Name = book.Publisher.Name
                },
                Authors = book.BookAuthors.Select(bookAuthor => new BookModel.AuthorModel
                {
                    Id = bookAuthor.Author.Id,
                    Name = bookAuthor.Author.FullName
                }).ToList(),
                Reviews = book.Reviews.Select(review => new BookModel.ReviewModel
                {
                    Id = review.Id,
                    Rating = review.Rating,
                    ReviewerName = review.ReviewerName,
                    ReviewText = review.ReviewText
                }).ToList()
            };
        }
    }
}
