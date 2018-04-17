using BooksAndMore.Catalogue.Domain.Common.Model;
using BooksAndMore.Catalogue.Domain.Model.Books;
using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Domain.Model.Authors
{
    public class Author : IEntity<int>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public string Bio { get; private set; }
        public AuthorType AuthorType { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }

        private Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public Author(string firstName, string lastName, string bio = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
        }
    }
}
