using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Web.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly BooksCatalogueContext _context;

        public BooksController(BooksCatalogueContext context)
        {
            _context = context;
        }

        // GET api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }
    }
}
