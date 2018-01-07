using BooksAndMore.Catalogue.Domain.Common;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class Book : IEntity<int>
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public string Description { get; private set; }
        public Publisher Publisher { get; private set; }
        public ICollection<Author> Authors { get; private set; }
        public ICollection<Review> Reviews { get; private set; }
    }
}
