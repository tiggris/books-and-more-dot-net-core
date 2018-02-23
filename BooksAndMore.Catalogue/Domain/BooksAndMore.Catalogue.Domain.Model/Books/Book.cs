using BooksAndMore.Catalogue.Domain.Common;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class Book : IEntity<int>
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public string Description { get; private set; }
        public Publisher Publisher { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }
        public ICollection<Review> Reviews { get; private set; }

        private Book()
        {
            Reviews = new HashSet<Review>();
        }

        public Book(string title, string isbn, string description, Publisher publisher, IList<Author> authors): this()
        {
            Title = title;
            Isbn = isbn;
            Description = description;
            Publisher = publisher;
            BookAuthors = authors?.Select(author => new BookAuthor(this, author)).ToList();
        }

        public void AddReview(int rating, string reviewerName = null, string reviewText = null)
        {
            Reviews.Add(new Review(rating, reviewerName, reviewText));
        }
    }
}