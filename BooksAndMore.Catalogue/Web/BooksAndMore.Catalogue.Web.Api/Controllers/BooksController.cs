using BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery;
using BooksAndMore.Catalogue.Application.Queries.TopBooksQuery;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Web.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly ITopBooksQuery _topBooksQuery;
        private readonly IBooksSearchQuery _booksSearchQuery;

        public BooksController(ITopBooksQuery topBooksQuery, IBooksSearchQuery booksSearchQuery)
        {
            _topBooksQuery = topBooksQuery;
            _booksSearchQuery = booksSearchQuery;
        }

        // GET api/books/top10
        [HttpGet("top10")]
        public TopBooksList GetTop10()
        {
            return _topBooksQuery.GetTopBooks(10);
        }

        // GET api/books/search
        [HttpGet("search")]
        public IList<BooksListItem> Search(string term)
        {
            return _booksSearchQuery.SearchBooks(term);
        }

        // GET api/books
        //[HttpGet]
        //public IEnumerable<Book> Get()
        //{
        //    return _context.Books.ToList();
        //}

        //// GET api/books/5
        //[HttpGet("{id}")]
        //public Book Get(int id)
        //{
        //    return _context.Books.Find(id);
        //}
    }
}
